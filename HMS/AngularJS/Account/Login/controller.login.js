actionApp.controller('loginCtrl', function ($scope, $filter, actionServices, commonService, DTOptionsBuilder, DTColumnBuilder) {
    $scope.actionList = [];

    $scope.init = function () {
        debugger;
        commonService.postWebService('Administration/ListActionMaster', {}).then(function (response) {
            $scope.actionList = response.liActionMaster;
            $scope.IsListDivVisible = true;
            $scope.IsEditDivVisible = false;
        });
        $scope.DatatableInitialize();
    };
    //$scope.sort = function (keyname) {
    //    $scope.sortKey = keyname;   //set the sortKey to the param passed
    //    $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    //}
    
    $scope.SaveActionMaster = function (ActionMaster) {
        if (ActionMaster.USER_ACTIVE == true) {
            ActionMaster.USER_ACTIVE = "1";
        } else {
            ActionMaster.USER_ACTIVE = "0";
        }
        var request = new actionServices.SaveActionMaster(ActionMaster);
        commonService.postWebService(request.url, request.param).then(function (response) {
            alert(response);
            $scope.init();
        });
    };
    $scope.submitForm = function (isValid, ActionMaster) {
        // check to make sure the form is completely valid
        if (isValid) {
            $scope.SaveActionMaster(ActionMaster);
        }
        else {
            angular.forEach($scope.ActionForm.$error.required, function (field) {
                field.$setDirty();
            });
        }

    };
    $scope.returnAcive = function (act) {
        return act == 1 ? 'Y' : 'N';
    };

    $scope.init();


});