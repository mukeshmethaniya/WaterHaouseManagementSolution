/// <reference path="angular.min.js" />
var app = angular.module('orderPlace', []).controller('orderPlaceController', function ($scope,$http) {
    $scope.Message = "Testing 53AA";
    $scope.selectedProduct = null;
    $scope.newOrderItemDetails = new Object();

    $scope.subTotal = 0;
    $scope.discount = 0;
    $scope.total = 0;

    var orderedItemA =
         {
             OrderId:"1",
             ProductID: "1",
             Quantity: "1",
             Discount: "6"
         };
    $scope.OrderedItemB = orderedItemA;

    $scope.customer = {
        Id:"1",
        CustomerType:"Mix",
        Name:"ABC",
        MobileNumber:"9876543210",
        Address:"Bharada",
        PrimaryRouteId:1,
        SecondaryRouteId:1,
        Remark:"Temp"

    }
    $scope.orderedItems = [];

    $scope.productSelectionChanged = function (selectedProduct) {

        $scope.newOrderItemDetails.ProductID = selectedProduct.Id;
        $scope.newOrderItemDetails.Name = selectedProduct.Name;
        $scope.newOrderItemDetails.Quantity = selectedProduct.Quantity;
        $scope.newOrderItemDetails.Price = selectedProduct.DefultPrize;

    };

    $scope.OnAddNewItemsForOrder = function (newOrderedItem) {

        var clonedNewOrderedItem =
         {
             OrderId:"1",
             ProductID: newOrderedItem.ProductID,
             Name: newOrderedItem.Name,
             PricePerUnit:newOrderedItem.Price,
             Quantity: newOrderedItem.Quantity,
             Discount: newOrderedItem.Discount
         };
        $scope.orderedItems.push(clonedNewOrderedItem);
        $scope.calculateTotal();
    };

    $scope.calculateTotal = function () {
        var tempSubTotal = 0;
        angular.forEach($scope.orderedItems, function (value) {
            tempSubTotal = tempSubTotal + value.Quantity * value.PricePerUnit;
        });
        $scope.subTotal = tempSubTotal;
        $scope.total = $scope.subTotal- $scope.discount;
    };

    $scope.SendData = function () {
        //var GetAll = new Object();
        //GetAll.Name = $scope.OrderedIem.Name;
        //GetAll.Quantity = $scope.OrderedIem.Quantity;
        //GetAll.UnitPrice = $scope.OrderedIem.UnitPrice;

        var order =
            {
                Id: 1,
                CustomerId: $scope.customer.Id,
                RouteId: $scope.customer.RouteId,
                SubTotal:$scope.subTotal,
                Discount: $scope.discount,
                Total: $scope.total,
                Date: new Date(),
                Info: "",

                ContactNumber: $scope.customer.MobileNumber,

            }

        var orderPlaceDecsk = {
            Customer: $scope.customer,
            Order: order,
            OrderedItems: $scope.orderedItems,


        };

        var orderedItems = $scope.orderedItems;
        $http({
            url: "Create",
            dataType: 'json',
            method: 'POST',
            data: orderPlaceDecsk,
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

    // In Controller
    $scope.search = function (val) {

        // fetch data
    }

})
;

app.directive('search', function () {
    return function ($scope, element) {
        element.bind("keyup", function (event) {
            var val = element.val();
            if(val.length > 2) {
                $scope.search(val);
            }
        });
    };
});


