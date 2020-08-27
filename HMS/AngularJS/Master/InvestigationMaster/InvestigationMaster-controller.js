investigationmstApp.controller('investigationmstCtrl', function ($scope, $filter, investigationServices, commonService, DTOptionsBuilder, DTColumnBuilder) {
    $scope.InvestigationList = [];
    $scope.obj = new investigationServices.investigationmstData(null);

    $scope.init = function () {
        debugger;
        commonService.postWebService('Master/BindListinvestigationmaster', {}).then(function (response) {
            $scope.InvestigationList = response.liInvestigationMaster;
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
    $scope.CancelInvestigationmaster = function () {
        $scope.IsListDivVisible = true;
        $scope.IsEditDivVisible = false;
        $scope.obj = null;
        $scope.InvestigationForm.$setPristine();
    };


    $scope.editClick = function (row, key, IsActive) {
        debugger;
        $scope.IsEditDivVisible = true;
        $scope.IsListDivVisible = false;
        if (key == 'E') {
            $scope.obj = new investigationServices.investigationmstData(row);
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
            $scope.obj = new investigationServices.investigationmstData(null);
            $scope.disablecode = false;
            $scope.obj.ISACTIVE = true;
            $scope.obj.KEY = key;
        }
    };
    $scope.submitForm = function (isValid, investigationmaster) {
        // check to make sure the form is completely valid
        debugger;
        if (isValid) {
            $scope.Saveinvestigationmaster(investigationmaster);
            $scope.InvestigationForm.$setPristine();
        }
        else {
            angular.forEach($scope.InvestigationForm.$error.required, function (field) {
                field.$setDirty();
            });
        }
    };

    $scope.Saveinvestigationmaster = function (investigationmaster) {
        if (investigationmaster.ISACTIVE == true) {
            investigationmaster.ISACTIVE = "1";

        }
        else {
            investigationmaster.ISACTIVE = "0";
        }
        var request = new investigationServices.Saveinvestigationmaster(investigationmaster);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;

            if (response.liInvestigationMaster != null) {
                if (response.liInvestigationMaster[0].MSG == "Updated Success") {
                    $("#Message").val('Updated !! ');//Messgae
                    $('#Title').html('Investigation Details Updated Successfully');//Title
                }
                else {
                    $("#Message").val('Saved !! ');//Messgae
                    $('#Title').html('InvestigationMater Saved Successfully');//Title
                }
                $("#Message").trigger("click");
                $scope.init();
                $scope.obj = null;
                $scope.InvestigationForm.$setPristine();
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
        $scope.obj = new investigationServices.investigationmstData(row);
        myFunctionCompany();
    }


});