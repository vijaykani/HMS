physicianApp.controller('physicianCtrl', function ($scope, $filter, physicianServices, commonService, DTOptionsBuilder, DTColumnBuilder) {
    $scope.physicianList = [];
    $scope.StateList = [];
    $scope.CityList = [];
    $scope.UserList = [];
    $scope.obj = new physicianServices.physicianData(null);

    $scope.init = function () {
        debugger;
        commonService.postWebService('Master/BindListphysicianMaster', {}).then(function (response) {
            $scope.physicianList = response.liphysicianMaster;
            $scope.CityList = response.liCityMaster;
            $scope.StateList = response.liStateMaster;
            $scope.UserList = response.liUserMaster;
            $scope.IsListDivVisible = true;
            $scope.IsEditDivVisible = false;
        });
        $scope.DatatableInitialize();
    };

    $scope.DatatableInitialize = function () {
        $scope.vm = {};
        $scope.vm.dtOptions = DTOptionsBuilder.newOptions()
		  .withOption('order', [0, 'asc']);;
    };
    $scope.Cancelphysicianmaster = function () {
        $scope.IsListDivVisible = true;
        $scope.IsEditDivVisible = false;
        $scope.obj = null;
        $scope.physicianForm.$setPristine();
    };

    $scope.BindCity = function (obj, key) {
        var request = new physicianServices.BindCity(obj);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;
            $scope.CityList = response.liCityMaster;
            if (key == 'E') {
                $scope.obj.City = obj.City;
            }
        });
    }
    $scope.editClick = function (row, key, IsActive) {
        debugger;
        $scope.IsEditDivVisible = true;
        $scope.IsListDivVisible = false;
        if (key == 'E') {
            $scope.obj = new physicianServices.physicianData(row);
            $scope.obj.KEY = key;
            if (row.ISACTIVE == 'N') {
                $scope.obj.ISACTIVE = false;
            }
            else {
                $scope.obj.ISACTIVE = true;
            }
            $scope.BindCity(row, "E");
        }
        else {
            $scope.obj = new physicianServices.physicianData(null);
            $scope.disablecode = false;
            $scope.obj.ISACTIVE = true;
            $scope.obj.KEY = key;
        }
    };
    $scope.submitForm = function (isValid, physicianmaster) {
        // check to make sure the form is completely valid
        debugger;
        if (isValid) {
            $scope.Savephysicianmaster(physicianmaster);
            $scope.physicianForm.$setPristine();
        }
        else {
            angular.forEach($scope.physicianForm.$error.required, function (field) {
                field.$setDirty();
            });
        }
    };

    $scope.Savephysicianmaster = function (physicianmaster) {
        if (physicianmaster.ISACTIVE == true) {
            physicianmaster.ISACTIVE = "1";

        }
        else {
            physicianmaster.ISACTIVE = "0";
        }
        var request = new physicianServices.Savephysicianmaster(physicianmaster);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;

            if (response.liphysicianMaster != null) {
                $("#Message").val('Saved !! ');//Messgae
                $('#Title').html('Physician  Details Saved Successfully');//Title
                $("#Message").trigger("click");
                $scope.init();
                $scope.obj = null;
                $scope.CustomerForm.$setPristine();
            }
            else {
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Error Happened while Saving Category');//Title
                $("#Message").trigger("click");
            }
        });

    };

    $scope.returnAcive = function (act) {
        return act == 1 ? 'Y' : 'N';
    };


    //$scope.showBankDetails = function () {

    //};

    $scope.init();


    $scope.myFunctionCompany = function (row, key) {
        $scope.obj = new physicianServices.physicianData(row);
        myFunctionCompany();
    }


});