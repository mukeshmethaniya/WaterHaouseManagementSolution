/// <reference path="OrderPlaceJavaScript.js" />
app.controller('dailyCustomerCreateController', function ($scope, $http) {

    $scope.customer = {
        Id: "1",
        CustomerType: "Mix",
        Name: "Daily Customer Name",
        MobileNumber: "9876543210",
        Address: "Bharada",
        PrimaryRouteId: 1,
        SecondaryRouteId: 1,
        Remark: "Temp"

    }

    $scope.getRoutes = function () {
        $http.get('/Route/GetAll')
        .success(function (data, status, headers, config) {
            //debugger;
            $scope.Routes = data;

        })
        .error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error while loading data!!';
            $scope.result = "color-red";

        });
    };
    $scope.getRoutes();

    $scope.getProducts = function () {
        $http.get('/Product/GetAll')
        .success(function (data, status, headers, config) {
            //debugger;
            $scope.Products = data;

        })
        .error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error while loading data!!';
            $scope.result = "color-red";

        });
    };
    $scope.getProducts();


       $scope.SendData = function () {
     

           var customer=$scope.customer;

        $http({
            url: "Create",
            dataType: 'json',
            method: 'POST',
            data: customer,
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            $scope.value = response;
        })
      .error(function (error) {
          alert(error);
      });
    };


});