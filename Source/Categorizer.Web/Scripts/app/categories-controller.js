angular.module('CategorizerApp', ['angular_taglist_directive'])
    .controller('CategoriesCtrl', function ($scope, $http) {

        $scope.baseUrl = "http://localhost:5010/api.svc/";
        
        $scope.categories = [];
        $scope.currentCategory = null;

        $scope.errorMessage = "";

        $scope.getKeywordsString = function(keywords) {
            var keywordValues = [];
            angular.forEach(keywords, function (keyword) {
                keywordValues.push(keyword.Value);
            });

            return keywordValues.join(', ');
        };

        $scope.createCategory = function () {

            $scope.errorMessage = "";

            $scope.currentCategory = {
                IsNew: true,
                NameLabel: "New Category",
                Name: "",
                Keywords: []
            };

            $('#editCategory').modal();
        };

        $scope.deleteSubmit = function() {
            $http.delete($scope.baseUrl + 'categories/' + $scope.currentCategory.Id).
            success(function () {
                $scope.init();
                $('#deleteCategory').modal("toggle");
            }).
            error(function (data) {
                $scope.errorMessage = data.Message;
            });
        };

        $scope.deleteCategory = function (category) {
            $scope.errorMessage = "";
            $scope.currentCategory = category;
            $('#deleteCategory').modal();

            $scope.currentCategory = {
                Id: category.Id,
                IsNew: false,
                NameLabel: category.Name,
                Name: category.Name
            };
        };

        $scope.submit = function () {
            
            if ($scope.currentCategory.IsNew) {

                var newCategory = {
                    Name: $scope.currentCategory.Name,
                    Keywords: []
                };

                angular.forEach($scope.currentCategory.Keywords, function (keyword) {
                    newCategory.Keywords.push({ Value: keyword });
                });

                $http.post($scope.baseUrl + 'categories', newCategory).
                success(function () {
                    $('#editCategory').modal("toggle");
                    $scope.init();
                }).
                error(function (data) {
                    $scope.errorMessage = data.Message;
                });
            } else {
                var changedCategory = {
                    Id: $scope.currentCategory.Id,
                    Name: $scope.currentCategory.Name,
                    Keywords: []
                };

                angular.forEach($scope.currentCategory.Keywords, function (keyword) {
                    changedCategory.Keywords.push({ Value: keyword });
                });

                $http.put($scope.baseUrl + 'categories', changedCategory).
                success(function () {
                    $('#editCategory').modal("toggle");
                    $scope.init();
                }).
                error(function (data) {
                    $scope.errorMessage = data.Message;
                });
            }
        };

        $scope.editCategory = function(category) {

            $scope.errorMessage = "";

            var keywordValues = [];
            angular.forEach(category.Keywords, function (keyword) {
                keywordValues.push(keyword.Value);
            });

            $scope.currentCategory = {
                Id: category.Id,
                IsNew: false,
                NameLabel: category.Name,
                Name: category.Name,
                Keywords: keywordValues
            };

            $('#editCategory').modal();
        };
        
        $scope.init = function () {

            $http.defaults.cache = false;

            $http.get($scope.baseUrl + 'categories').
            success(function (data) {
                $scope.categories = data;
            }).
            error(function () {
            });

        };
    });