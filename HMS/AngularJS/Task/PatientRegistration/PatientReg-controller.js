patientregApp.controller('patientregCtrl', function ($scope, $filter, patientregServices, commonService, DTOptionsBuilder, DTColumnBuilder) {
    $scope.patientregList = [];
    $scope.StateList = [];
    $scope.CityList = [];
    $scope.obj = new patientregServices.patientregData(null);

    $scope.init = function () {
        debugger;
        commonService.postWebService('Task/BindListpatientreg', {}).then(function (response) {
            $scope.patientregList = response.liPatientreg;
            $scope.CityList = response.liCityMaster;
            $scope.StateList = response.liStateMaster;
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
    $scope.Cancelpatientreg = function () {
        $scope.IsListDivVisible = true;
        $scope.IsEditDivVisible = false;
        $scope.obj = null;
        $scope.patientregForm.$setPristine();
    };

    $scope.BindCity = function (obj, key) {
        var request = new patientregServices.BindCity(obj);
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
            $scope.obj = new patientregServices.patientregData(row);
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
            $scope.obj = new patientregServices.patientregData(null);
            $scope.disablecode = false;
            $scope.obj.ISACTIVE = true;
            $scope.obj.KEY = key;
        }
    };
    $scope.submitForm = function (isValid, patientreg) {
        // check to make sure the form is completely valid
        debugger;
        if (isValid) {
            $scope.Savepatientreg(patientreg);
            $scope.patientregForm.$setPristine();
        }
        else {
            angular.forEach($scope.patientregForm.$error.required, function (field) {
                field.$setDirty();
            });
        }
    };

    $scope.Savepatientreg = function (patientreg) {
        if (patientreg.ISACTIVE == true) {
            patientreg.ISACTIVE = "1";

        }
        else {
            patientreg.ISACTIVE = "0";
        }
        var request = new patientregServices.Savepatientreg(patientreg);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;

            if (response.liPatientreg != null) {
                if (response.liPatientreg[0].MSG == "Updated Success") {
                    $("#Message").val('Updated !! ');//Messgae
                    $('#Title').html('Patient Details Updated Successfully' + '<br/>' + 'Patient Number :  ' + response.liPatientreg[0].Patient_no);//Title
                }
                else {
                    $("#Message").val('Saved !! ');//Messgae
                    $('#Title').html('Patient  Details Saved Successfully' + '<br/>' + 'Patient Number :  ' + response.liPatientreg[0].Patient_no);//Title
                }
                $("#Message").trigger("click");
                $scope.init();
                $scope.obj = null;
                $scope.patientregForm.$setPristine();
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
        $scope.obj = new patientregServices.patientregData(row);
        myFunctionCompany();
    }


});