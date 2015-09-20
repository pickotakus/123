var TodoApp = angular.module("TodoApp", ["ngResource"]).
    config(function($routeProvider) {
        $routeProvider.
            when('/', { controller: ListCtrl, templateUrl: 'list.html' }).
            when('/new', { controller: CreateCtrl, templateUrl: 'detail.html' }).
            when('/newsub/:itemId', { controller: CreateSubCtrl, templateUrl: 'sub-detail.html' }).
            when('/editsub/:itemId', { controller: EditSubCtrl, templateUrl: 'sub-detail.html' }).
            when('/edit/:itemId', { controller: EditCtrl, templateUrl: 'detail.html' }).
            otherwise({ redirectTo: '/' });
    });

TodoApp.factory('Todo',
    function ($resource) {return $resource('/api/todo/:id', { id: '@id' }, { update: { method: 'PUT' } });
    });
TodoApp.factory('TodoSub',
    function ($resource) {
        return $resource('/api/SubItems/:id', { id: '@id' }, { update: { method: 'PUT' } });
    });

var ListCtrl = function ($scope, $location, Todo) {
    $scope.search = function() {
        Todo.query({
                q: $scope.query,
                limit: $scope.limit,
                offset: $scope.offset,
                sort: $scope.sort_order,
                desc: $scope.sort_desc
            },
            function(items) {
                var cnt = items.length;
                $scope.no_more = cnt < 20;
                $scope.items = $scope.items.concat(items);
            }
        );
    };

    $scope.reset = function () {
        $scope.offset = 0;
        $scope.items = [];
        $scope.search();
    };
    
    $scope.show_more = function () { return !$scope.no_more; };

    $scope.sort_by = function (ord) {
        if ($scope.sort_order == ord) { $scope.sort_desc = !$scope.sort_desc; }
        else { $scope.sort_desc = false; }
        $scope.sort_order = ord;
        $scope.items = [];
        $scope.search();
    };

    $scope.delete = function () {
        var itemId = this.item.TodoItemId;
        Todo.delete({ id: itemId }, function () {
            $("#item_" + itemId).fadeOut();
        });
    };

    
    $scope.limit = 20;
    $scope.sort_order = 'Priority';
    $scope.sort_desc = false;

    $scope.reset();
};

var CreateCtrl = function ($scope, $location, Todo) {
    $scope.btnName = "Pievienot";

    $scope.save = function() {
        Todo.save($scope.item, function() {
            $location.path('/');
        });
    };
};

var CreateSubCtrl = function ($scope, $routeParams, $location, TodoSub) {
    $scope.btnName = "Pievienot";
    $scope.mainCatIDforitem = $routeParams.itemId;
    $scope.priorityImgUrl = 'Images/priority_off.bmp'
    datepickr('#day');

    $scope.toggleImage = function () {
        if ($scope.priorityImgUrl == 'Images/priority_off.bmp') {
            $scope.priorityImgUrl = 'Images/priority_on.png';
        } else {
            $scope.priorityImgUrl = 'Images/priority_off.bmp';
        }
    }

    $scope.save = function () {
        $scope.item.MainCategoryID = $routeParams.itemId;
        $scope.item.Subtasks = $('#day').val();

        if ($scope.priorityImgUrl == 'Images/priority_off.bmp')
            $scope.item.Priority = false;
        else
            $scope.item.Priority = true;
        TodoSub.save($scope.item, function () {
            window.history.back();
        });
    };
};

var EditCtrl = function ($scope, $routeParams, $location, Todo) {
    $scope.item = Todo.get({ id: $routeParams.itemId });
    $scope.btnName = "Rediģēt";
    
    $scope.save = function () {
        Todo.update({id: $scope.item.TodoItemId}, $scope.item, function () {
            $location.path('/');
        });
    };
};

var EditSubCtrl = function ($scope, $routeParams, $location, TodoSub) {
    $scope.item = TodoSub.get({ id: $routeParams.itemId });
    $scope.btnName = "Rediģēt";

    $scope.save = function () {
        TodoSub.update({ id: $scope.item.TodoItemId }, $scope.item, function () {
            window.history.back();
        });
    };
};


function subitemsController($scope, $routeParams, $http) {
    $scope.mainID = $routeParams.itemId;

    $http.get('api/SubItems').success(function (data) {
        var unfiltered = [];
        angular.forEach(data, function (maincatid, MainCategoryID) {
            if (maincatid.MainCategoryID == $routeParams.itemId) {
                unfiltered.push(maincatid);
            }
        });
        $scope.items = unfiltered;
    })
    .error(function (data) { alert(data);});

}

TodoApp.directive('sorted', function() {
    return {
        scope: true,
        transclude: true,
        template: '<a ng-click="do_sort()" ng-transclude></a>' +
            '<span ng-show="do_show(true)"><i class="icon-circle-arrow-down"></i></span>' +
            '<span ng-show="do_show(false)"><i class="icon-circle-arrow-up"></i></span>',

        controller: function($scope, $element, $attrs) {
            $scope.sort = $attrs.sorted;

            $scope.do_sort = function() { $scope.sort_by($scope.sort); };

            $scope.do_show = function(asc) {
                return (asc != $scope.sort_desc) && ($scope.sort_order == $scope.sort);
            };
        }
    };
});
