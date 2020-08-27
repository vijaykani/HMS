drugmstApp.controller('drugmstCtrl', function ($scope, $filter, drugServices, commonService, DTOptionsBuilder, DTColumnBuilder) {
    $scope.DrugList = [];
    $scope.obj = new drugServices.drugmstData(null);

    $scope.init = function () {
        debugger;
        commonService.postWebService('Master/BindListdrugmaster', {}).then(function (response) {
            $scope.DrugList = response.liDrugMaster;
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
    $scope.Canceldrugmaster = function () {
        $scope.IsListDivVisible = true;
        $scope.IsEditDivVisible = false;
        $scope.obj = null;
        $scope.DrugForm.$setPristine();
    };


    $scope.editClick = function (row, key, IsActive) {
        debugger;
        $scope.IsEditDivVisible = true;
        $scope.IsListDivVisible = false;
        if (key == 'E') {
            $scope.obj = new drugServices.drugmstData(row);
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
            $scope.obj = new drugServices.drugmstData(null);
            $scope.disablecode = false;
            $scope.obj.ISACTIVE = true;
            $scope.obj.KEY = key;
        }
    };
    $scope.submitForm = function (isValid, drugmaster) {
        // check to make sure the form is completely valid
        debugger;
        if (isValid) {
            $scope.Savedrugmaster(drugmaster);
            $scope.DrugForm.$setPristine();
        }
        else {
            angular.forEach($scope.DrugForm.$error.required, function (field) {
                field.$setDirty();
            });
        }
    };

    $scope.Savedrugmaster = function (drugmaster) {
        if (drugmaster.ISACTIVE == true) {
            drugmaster.ISACTIVE = "1";

        }
        else {
            drugmaster.ISACTIVE = "0";
        }
        var request = new drugServices.Savedrugmaster(drugmaster);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;

            if (response.liDrugMaster != null) {
                if (response.liDrugMaster[0].MSG == "Updated Success") {
                    $("#Message").val('Updated !! ');//Messgae
                    $('#Title').html('Drug Details Updated Successfully');//Title
                }
                else {
                    $("#Message").val('Saved !! ');//Messgae
                    $('#Title').html('DrugMater Saved Successfully');//Title
                }
                $("#Message").trigger("click");
                $scope.init();
                $scope.obj = null;
                $scope.DrugForm.$setPristine();
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
        $scope.obj = new drugServices.drugmstData(row);
        myFunctionCompany();
    }


});