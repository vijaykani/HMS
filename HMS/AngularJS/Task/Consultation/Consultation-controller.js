consultationApp.controller('consultationCtrl', function ($scope, $filter, consultationServices, commonService, DTOptionsBuilder, DTColumnBuilder, $http) {
    $scope.PatientList = [];
    $scope.DoseList = [];
    $scope.TestdetailList = [];
    $scope.DrugList = [];
    $scope.PrintList = [];
    $scope.DiagnosisList = [];
    $scope.PrescriptionList = [];
    $scope.TestList = [];
    $scope.VitalsList = [];
    $scope.obj = new consultationServices.consultationData(null);

    var patientIdvital;
    var app = angular.module('app', []);

    app.directive('numbersOnly', function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attr, ngModelCtrl) {
                function fromUser(text) {
                    if (text) {
                        var transformedInput = text.replace(/[^0-9]/g, '');

                        if (transformedInput !== text) {
                            ngModelCtrl.$setViewValue(transformedInput);
                            ngModelCtrl.$render();
                        }
                        return transformedInput;
                    }
                    return undefined;
                }
                ngModelCtrl.$parsers.push(fromUser);
            }
        };
    });

    var myApp = angular.module('myApp', []);
    myApp.controller('myController',
        function ($scope, $window) {

            $scope.setFocus = function () {
                var Symtoms = $window.document.getElementById('Symtoms');
                var BP_systolic = $window.document.getElementById('BP_systolic');
                if (Symtoms.value != '')
                    BP_systolic.focus();
                else {
                    alert('Invalid name');
                    name.focus();
                }
            };
        });

   
    
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


    $scope.Cancelpatientreg = function () {
        $scope.IsListDivVisible = true;
        $scope.IsEditDivVisible = false;
        $scope.obj = null;
        $scope.patientregForm.$setPristine();
    };

    $scope.BindCity = function (obj, key) {
        var request = new consultationServices.BindCity(obj);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;
            $scope.CityList = response.liCityMaster;
            if (key == 'E') {
                $scope.obj.City = obj.City;
            }
        });
    }

    $scope.setFiles = function (element) {
        $scope.$apply(function (scope) {
            $scope.AttachStatus = "";
            $scope.files = []
            for (var i = 0; i < element.files.length; i++) {
                $scope.files.push(element.files[i])
            }

        });
    }

    $scope.fnUpload = function (file, uploadurl) {

        var reqObj = new XMLHttpRequest();

        reqObj.open("POST", "/Task/AttachFile", true);
        reqObj.setRequestHeader("Content-Type", "multipart/form-data");
        reqObj.setRequestHeader('X-File-Name', file.name);
        reqObj.setRequestHeader('X-File-Type', file.type);
        reqObj.setRequestHeader('X-File-Size', file.size);
        reqObj.setRequestHeader('X-File-UploadURL', uploadurl);
        reqObj.send(file);//$scope.files[0].

    }

    $scope.Download = function () {
        //var filename = 
        var downloadurl = "D://Projects//HMS//HMS//HMS//UploadDocument//" + $scope.PatientVisitID + "//" + "TestOrder" + "//" + $scope.obj.Test_id + "//";
        for (var i = 0; i < $scope.files.length; i++) {
            window.location = '/Task/Download?fileName=' + $scope.files[i].name + '&downloadurl=' + downloadurl;
        }


    };


    $scope.initdiagnosisdetails = function () {
        debugger;
        commonService.postWebService('Task/BindListDiagnosisdetail', {}).then(function (response) {
            $scope.DiagnosisList = response.liDiagnosisdetail;
            $scope.IsListDiagnosisDivVisible = true;
            $scope.IsEditDiagnosisVisible = false;
        });
        $scope.DatatableInitialize();
    };

    $scope.initdiagnosisdetailslist = function (consultation) {
        debugger;
        consultation.PatientVisitID = $scope.PatientVisitID;
        debugger;
        var request = new consultationServices.ListDiagnosisdetail(consultation);
        commonService.postWebService(request.url, request.param).then(function (response) {
            $scope.DiagnosisList = response.liDiagnosisdetail;
            $scope.IsListDiagnosisDivVisible = true;
            $scope.IsEditDiagnosisVisible = false;
        });
        $scope.DatatableInitialize();
    };

    $scope.initprescriptiondetails = function () {
        debugger;
        commonService.postWebService('Task/BindListDrugdetail', {}).then(function (response) {
            $scope.PrescriptionList = response.liDrugdetails;
            $scope.DoseList = response.lidosemst;
            $scope.DrugList = response.lidrugmst;
            $scope.IsListPrescriptionDivVisible = true;
            $scope.IsEditPrescriptionVisible = false;
        });
        $scope.DatatableInitialize();
    };

    $scope.initprescriptiondetailslist = function (consultation) {
        debugger;
        consultation.PatientVisitID = $scope.PatientVisitID;
        debugger;
        var request = new consultationServices.ListDrugdetail(consultation);
        commonService.postWebService(request.url, request.param).then(function (response) {
            $scope.PrescriptionList = response.liDrugdetails;
            $scope.DoseList = response.lidosemst;
            $scope.DrugList = response.lidrugmst;
            $scope.IsListPrescriptionDivVisible = true;
            $scope.IsEditPrescriptionVisible = false;
            $scope.removeDrugList();
        });
        $scope.DatatableInitialize();
    };


    $scope.initTestdetails = function () {
        debugger;
        commonService.postWebService('Task/BindListTestdetail', {}).then(function (response) {
            $scope.TestList = response.liTestdetails;
            $scope.TestdetailList = response.litestmst;
            $scope.IsListTestDivVisible = true;
            $scope.IsEditTestVisible = false;
        });
        $scope.DatatableInitialize();
    };

    $scope.initTestdetailslist = function (consultation) {
        debugger;
        consultation.PatientVisitID = $scope.PatientVisitID;
        debugger;
        var request = new consultationServices.ListTestdetail(consultation);
        commonService.postWebService(request.url, request.param).then(function (response) {
            $scope.TestList = response.liTestdetails;
            $scope.TestdetailList = response.litestmst;
            $scope.IsListTestDivVisible = true;
            $scope.IsEditTestVisible = false;
            $scope.removetTestList();
        });
        $scope.DatatableInitialize();
    };
    $scope.initVitalsdetails = function () {
        debugger;

        // consultation.Patient_Id = $('input[id="checkbox-p-fill-1"]:checked').val();
        commonService.postWebService('Task/BindListVitalsdetail', {}).then(function (response) {
            $scope.VitalsList = response.liVitals;
        });
        $scope.DatatableInitialize();
    };
    $scope.initVitalsdetailslist = function (consultation) {
        debugger;
        consultation.PatientVisitID = $scope.PatientVisitID;
        debugger;
        var request = new consultationServices.ListVitalsdetail(consultation);
        commonService.postWebService(request.url, request.param).then(function (response) {
            $scope.VitalsList = response.liVitals;
        });
        $scope.DatatableInitialize();
    };

    $scope.DatatableInitialize = function () {
        $scope.vm = {};
        $scope.vm.dtOptions = DTOptionsBuilder.newOptions()
            .withOption('order', [0, 'asc']);;
    };

    $scope.Cancelsymptomsmaster = function () {
        $scope.IsListSymptomsDivVisible = true;
        $scope.IsEditSymptomsVisible = false;

        $scope.obj = null;
        $scope.SymptomsForm.$setPristine();
    };
    $scope.CancelDiagnosismaster = function () {
        $scope.IsListDiagnosisDivVisible = true;
        $scope.IsEditDiagnosisVisible = false;

        $scope.obj = null;
        $scope.DiagnosisForm.$setPristine();
    };

    $scope.CancelPrescriptionmaster = function () {
        $scope.IsListPrescriptionDivVisible = true;
        $scope.IsEditPrescriptionVisible = false;

        $scope.obj = null;
        $scope.PrescriptionForm.$setPristine();
    };
    $scope.CancelTestmaster = function () {
        $scope.IsListTestDivVisible = true;
        $scope.IsEditTestVisible = false;

        $scope.obj = null;
        $scope.TestForm.$setPristine();
    };



    $scope.submitFormVitals = function (isValid, consultation) {
        // check to make sure the form is completely valid
        //if ($scope.isSaved == 'Y') {

        //$("#Message").val('Failed !! ');//Messgae
        //$('#Title').html('Already Vitals Details Saved');//Title
        //$("#Message").trigger("click");
        //}
        //else {
     //   setFocus();
        if (isValid) {
            if ((typeof $('input[id="checkbox-p-fill-1"]:checked').val() === 'undefined') || ($('input[id="checkbox-p-fill-1"]:checked').val() == "")) {
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Select Patient List');//Title
                $("#Message").trigger("click");

            }
            else {
                $scope.IsListVitalsdetailVisible = false;
                $scope.SaveVitalsmaster(consultation);
                $scope.VitalsForm.$setPristine();
            }
        }
        else {
            angular.forEach($scope.VitalsForm.$error.required, function (field) {
                field.$setDirty();
            });
        }
        //}
    };

    $scope.SaveVitalsmaster = function (consultation) {
        debugger;
       
        consultation.Patient_Id = $('input[id="checkbox-p-fill-1"]:checked').val();
        debugger;
        var request = new consultationServices.SaveVitalsmaster(consultation);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;

            if (response.liVitals != null) {
                $("#Message").val('Saved !! ');//Messgae
                $('#Title').html('Vitals  Details Saved Successfully');//Title
                $("#Message").trigger("click");
                $scope.PatientVisitID = response.liVitals[0].PatientVisitID;
                $scope.initVitalsdetailslist(consultation);
                $scope.isSaved = 'Y';

                $scope.IsListVitalsdetailVisible = true;
                $scope.obj = null;
                // $scope.PatientVisitID = response.liVitals[0].PatientVisitID;
                $scope.PrescriptionForm.$setPristine();
                // $scope.PatientVisitID = response.liVitals[0].PatientVisitID;
                patientIdvital = $scope.PatientVisitID;
            }
            else {
                $scope.isSaved = 'N';
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Error Happened while Saving Vitals');//Title
                $("#Message").trigger("click");
            }
        });

    };


    $scope.editClick = function (row, key, IsActive) {
        debugger;
        //$scope.initVitalsdetails();
        //if ($scope.VitalsList[0] != null) {
        if ($scope.isSaved == 'Y') {
            $scope.IsEditDiagnosisVisible = true;
            $scope.IsListDiagnosisDivVisible = false;
            if (key == 'E') {
                $scope.obj = new consultationServices.consultationData(row);
                $scope.obj.KEY = key;
            }
            else {
                $scope.obj = new consultationServices.consultationData(null);
                $scope.obj.KEY = key;
            }
        }
        else {
            $("#Message").val('Failed !! ');//Messgae
            $('#Title').html('Please Save Vitals Details!!');//Title
            $("#Message").trigger("click");

        }
    };





    $scope.submitForm = function (isValid, consultation) {
        consultation.PatientVisitID = $scope.PatientVisitID;
        // check to make sure the form is completely valid
        debugger;
        if (isValid) {
            $scope.SaveDiagnosismaster(consultation);
            $scope.DiagnosisForm.$setPristine();
        }
        else {
            angular.forEach($scope.DiagnosisForm.$error.required, function (field) {
                field.$setDirty();
            });
        }
    };


    $scope.SaveDiagnosismaster = function (consultation) {
        debugger;
        consultation.PatientVisitID = $scope.PatientVisitID;
        // consultation.Patient_Id = $('input[id="checkbox-p-fill-1"]:checked').val();
        var request = new consultationServices.SaveDiagnosismaster(consultation);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;
            if (response.liDiagnosisdetail != null) {
                $("#Message").val('Saved !! ');//Messgae
                $('#Title').html('Diagnosis  Details Saved Successfully');//Title
                $("#Message").trigger("click");
                //$scope.init();
                $scope.initdiagnosisdetailslist(consultation);
                $scope.obj = null;
                $scope.DiagnosisForm.$setPristine();
            }
            else {
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Error Happened while Saving Category');//Title
                $("#Message").trigger("click");
            }
        });

    };

    $scope.DeleteDiagnosisMaster = function (consultation) {
        var request = new consultationServices.DeleteDiagnosisMaster(consultation);
        commonService.postWebService(request.url, request.param).then(function (response) {
            if (response != null && response.liDiagnosisdetail[0].MSG == "Deleted Success") {
                $("#Message").val('Deleted !! ');//Messgae
                $('#Title').html('Diagnosis  Details Deleted Successfully');//Title
                $("#Message").trigger("click");
                // $scope.init();
                $scope.initdiagnosisdetailslist(consultation);
                $scope.obj = null;
                $scope.DiagnosisForm.$setPristine();
            }
            else {
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Error Happened while Deleting Category');//Title
                $("#Message").trigger("click");
            }
        });
    };


    $scope.DeleteVitalsMaster = function (consultation) {
        consultation.PatientVisitID = $scope.PatientVisitID;
        var request = new consultationServices.DeleteVitalsMaster(consultation);
        commonService.postWebService(request.url, request.param).then(function (response) {
            if (response != null && response.liVitals[0].MSG == "Deleted Success") {
                $("#Message").val('Deleted !! ');//Messgae
                $('#Title').html('Vitals  Details Deleted Successfully');//Title
                $("#Message").trigger("click");
                $scope.initVitalsdetailslist(consultation);
                $scope.initdiagnosisdetailslist(consultation);
                $scope.initprescriptiondetailslist(consultation);
                $scope.initTestdetailslist(consultation);
                $scope.isSaved = 'N';
                $scope.IsListVitalsdetailVisible = false;
                // $scope.init();
                //   $scope.initVitalsdetails();
                $scope.obj = null;
                $scope.PrescriptionForm.$setPristine();
            }
            else {
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Error Happened while Deleting Category');//Title
                $("#Message").trigger("click");
            }
        });
    };
    $scope.submitFormprecription = function (isValid, consultation) {
        // check to make sure the form is completely valid
        debugger;
        if (isValid) {
            $scope.SavePrecriptionmaster(consultation);
            $scope.PrescriptionForm.$setPristine();
        }
        else {
            angular.forEach($scope.PrescriptionForm.$error.required, function (field) {
                field.$setDirty();
            });
        }
    };

    $scope.submitFormPatient = function (isValid, patientreg) {
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
        var request = new consultationServices.Savepatientreg(patientreg);
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

    $scope.submitFormTest = function (isValid, consultation) {
        // check to make sure the form is completely valid
        debugger;
        if (isValid) {
            $scope.SaveTestmaster(consultation);
            $scope.TestForm.$setPristine();
        }
        else {
            angular.forEach($scope.TestForm.$error.required, function (field) {
                field.$setDirty();
            });
        }
    };
    $scope.filterConHeaderLst = function (DrugList) {
        return (DrugList.DRUGID );
    }
    $scope.removeDrugList=function()
    {
        angular.forEach($scope.PrescriptionList, function (value, key) {
            for (k = 0; k < $scope.DrugList.length; k++) {
                var a = $scope.DrugList[k].DRUGNAME.indexOf(value.DrugName);
                if (a > -1) {
                    $scope.DrugList.splice(k, 1);
                    return false;
                }
            }
        });
    }

    $scope.removetTestList = function () {
        angular.forEach($scope.TestList, function (value, key) {
            for (k = 0; k < $scope.TestdetailList.length; k++) {
                var a = $scope.TestdetailList[k].INVNAME.indexOf(value.InvName);
                if (a > -1) {
                    $scope.TestdetailList.splice(k, 1);
                    return false;
                }
            }
        });
    }
    $scope.SavePrecriptionmaster = function (consultation) {
        consultation.PatientVisitID = $scope.PatientVisitID;
        //$scope.SelectedProduct = $filter('filster')($scope.DrugList, { 'DRUGID': DRUGID });
        //$scope.filterConHeaderLst = function (DrugList,PrescriptionList) {
        //    return (DrugList.DRUGNAME != PrescriptionList[0].DrugName);
        //}
       
        var request = new consultationServices.SavePrecriptionmaster(consultation);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;

            if (response.liDrugdetails != null) {
                $("#Message").val('Saved !! ');//Messgae
                $('#Title').html('Drug  Details Saved Successfully');//Title
                $("#Message").trigger("click");
                //  $scope.init();
                $scope.initprescriptiondetailslist(consultation);
                $scope.obj = null;
                $scope.PrescriptionForm.$setPristine();
            }
            else {
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Error Happened while Saving Category');//Title
                $("#Message").trigger("click");
            }
        });

    };
    $scope.SaveTestmaster = function (consultation) {

        consultation.PatientVisitID = $scope.PatientVisitID;
        consultation.Test_Uploadfilename = '';
        //Document upload
        var uploadurl = "D://Projects//HMS//HMS//HMS//UploadDocument//" + consultation.PatientVisitID + "//" + "TestOrder" + "//" + $scope.obj.Test_id + "//";
        if ($scope.files.length > 0) {
            for (var i = 0; i < $scope.files.length; i++) {
                $scope.fnUpload($scope.files[i], uploadurl);
                // $scope.fnDownLoad($scope.files[i], uploadurl);
                if (i == 0)
                    consultation.Test_Uploadfilename = $scope.files[i].name;
                else
                    consultation.Test_Uploafdfilename = consultation.Test_Uploadfilename + ";" + $scope.files[i].name;
            }
        }
        consultation.Test_Uploadpath = uploadurl;
        //consultation.Test_Uploadfilename = $scope.files[0].name;
        var request = new consultationServices.SaveTestmaster(consultation);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;

            if (response.liTestdetails != null) {
                $("#Message").val('Saved !! ');//Messgae
                $('#Title').html('Test  Details Saved Successfully');//Title
                $("#Message").trigger("click");
                $scope.initTestdetailslist(consultation);

                $scope.TestForm.$setPristine();


                $scope.obj = null;
                //$scope.files = [];
            }
            else {
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Required Vitals Details');//Title
                $("#Message").trigger("click");
            }
        });

    };
    $scope.testNameChange = function () {
        $scope.files = [];
    }
    $scope.editClickPatient = function (row, key, IsActive) {
        debugger;
        $scope.IsEditDivVisible = true;
        $scope.IsListDivVisible = false;
        if (key == 'E') {
            $scope.obj = new consultationServices.patientregData(row);
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
            $scope.obj = new consultationServices.patientregData(null);
            $scope.disablecode = false;
            $scope.obj.ISACTIVE = true;
            $scope.obj.KEY = key;
        }
    };

    $scope.editClickoption = function (row) {
        $scope.IsListVitalsdetailVisible = false;
        $scope.isSaved = 'N';
        $scope.isprintSaved == 'N'
        //$scope.init();
        $scope.initdiagnosisdetails();
        $scope.initprescriptiondetails();
        $scope.initTestdetails();
        //$scope.initVitalsdetails();
        //$scope.obj = null;
        //$scope.VitalsForm.$setPristine();
    };

    $scope.editClickPrescription = function (row, key, IsActive) {
        debugger;
        if ($scope.isSaved == 'Y') {
            $scope.IsEditPrescriptionVisible = true;
            $scope.IsListPrescriptionDivVisible = false;
            if (key == 'E') {
                $scope.obj = new consultationServices.consultationData(row);
                $scope.obj.KEY = key;
            }
            else {
                $scope.obj = new consultationServices.consultationData(null);
                $scope.obj.KEY = key;
            }
        }
        else {
            $("#Message").val('Failed !! ');//Messgae
            $('#Title').html('Required Vitals Details');//Title
            $("#Message").trigger("click");

        }
    };

    $scope.editClickVitals = function (row, key, IsActive) {
        if (key == 'E') {
            $scope.obj = new consultationServices.consultationData(row);
            $scope.obj.KEY = key;
        }
        else {
            $scope.obj = new consultationServices.consultationData(null);
            $scope.obj.KEY = key;
        }
    };

    $scope.editClickTest = function (row, key, IsActive) {
        debugger;
        if ($scope.isSaved == 'Y') {
            $scope.IsListTestDivVisible = false;
            $scope.IsEditTestVisible = true;
            if (key == 'E') {
                $scope.obj = new consultationServices.consultationData(row);
                $scope.obj.KEY = key;
            }
            else {
                $scope.obj = new consultationServices.consultationData(null);
                $scope.obj.KEY = key;
            }
        }
        else {
            $("#Message").val('Failed !! ');//Messgae
            $('#Title').html('Required Vitals Details');//Title
            $("#Message").trigger("click");

        }
    };

    $scope.DeletePrecriptionMaster = function (consultation) {
        var request = new consultationServices.DeletePrecriptionMaster(consultation);
        commonService.postWebService(request.url, request.param).then(function (response) {
            if (response != null && response.liDrugdetails[0].MSG == "Deleted Success") {
                $("#Message").val('Deleted !! ');//Messgae
                $('#Title').html('Drug Details Deleted Successfully');//Title
                $("#Message").trigger("click");
                //$scope.init();
                $scope.initprescriptiondetailslist(consultation);
                $scope.obj = null;
                $scope.PrescriptionForm.$setPristine();
            }
            else {
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Error Happened while Deleting Category');//Title
                $("#Message").trigger("click");
            }
        });
    };



    $scope.DeleteTestMaster = function (consultation) {
        consultation.PatientVisitID = $scope.PatientVisitID;
        var request = new consultationServices.DeleteTestMaster(consultation);
        commonService.postWebService(request.url, request.param).then(function (response) {
            if (response != null && response.liTestdetails[0].MSG == "Deleted Success") {
                $("#Message").val('Deleted !! ');//Messgae
                $('#Title').html('Test Details Deleted Successfully');//Title
                $("#Message").trigger("click");
                $scope.initTestdetailslist(consultation);
                $scope.obj = null;
                $scope.TestForm.$setPristine();
            }
            else {
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Error Happened while Deleting Category');//Title
                $("#Message").trigger("click");
            }
        });
    };




    //$scope.PrintConsulation = function (consultation) {
    //    debugger;
    //    $scope.Print = true;
    //    consultation.PatientVisitID = $scope.PatientVisitID;

    //    // consultation.Patient_Id = $('input[id="checkbox-p-fill-1"]:checked').val();
    //    commonService.postWebService('Task/PrintConsultation', {}).then(function (response) {
    //        $scope.VitalsList = response.liVitals;
    //    });
    //    $scope.DatatableInitialize();
    //};

    $scope.PrintConsulation = function (consultation) {

        //if ($scope.isprintSaved == 'Y') {
            debugger;
            //  $scope.Print = true;
            $scope.obj = new consultationServices.consultationData(null);
            $scope.obj.PatientVisitID = patientIdvital;

            var request = new consultationServices.Printdetail($scope.obj);
            commonService.postWebService(request.url, request.param).then(function (response) {
                $scope.PrintList = response.liprintdetails;
                $('#lblDocNam').text(response.liprintdetails[0].DOCTORNAME);
                $('#lblspeciality').text(response.liprintdetails[0].SPECIALITY);
                $('#lbladdress').text(response.liprintdetails[0].OrgDisplayAddress);
                $('#lblemaildoctor').text(response.liprintdetails[0].email_address);
                $('#lbldmobileno').text(response.liprintdetails[0].DMOBILENO);
                $('#lblpname').text(response.liprintdetails[0].PatientName);
                $('#lblage').text(response.liprintdetails[0].Age);
                $('#lblsex').text(response.liprintdetails[0].Sex);
                $('#lblpmobileno').text(response.liprintdetails[0].PMobileno);
                $('#lblBP').text(response.liprintdetails[0].BP_systolic);
                $('#lblBPdia').text(response.liprintdetails[0].BP_Diastolic);
                $('#lbldreport').text(response.liprintdetails[0].Doctorreport);

                $scope.Email = response.liprintdetails[0].email_address;
            });
            $scope.DatatableInitialize();
            $scope.PrintConsulationdrug();
        //}

        //else
        //{
        //    $("#Message").val('Failed !! ');//Messgae
        //    $('#Title').html('Save Patient Details');//Title
        //    $("#Message").trigger("click");
        //}
    };


    //$scope.Sendmail = function (consultation) {
    //    $scope.obj = new consultationServices.consultationData(null);
    //    $scope.obj.PatientVisitID = patientIdvital;
    //    var request = new consultationServices.Sendmail();
    //    commonService.postWebService(request.url, request.param).then(function (response) {
    //    });
    //    $scope.DatatableInitialize();
    //};

    $scope.Sendmail = function (consultation) {
        //$scope.PrintConsulation();
       // consultation.Email = $scope.Email;
        //   commonService.postWebService('Task/sendmail', {}).then(function (response) {
        $scope.obj = new consultationServices.consultationData(null);
        $scope.obj.PatientVisitID = patientIdvital;
            var request = new consultationServices.Sendmail($scope.obj);
        commonService.postWebService(request.url, request.param).then(function (response) {
        });
        $scope.DatatableInitialize();
    };
   

    //$scope.SavePrescription = function (consultation) {
    //    $scope.obj = new consultationServices.consultationData(null);
    //    $scope.obj.PatientVisitID = patientIdvital;
    //    var request = new consultationServices.SavePrescription($scope.obj);
    //    commonService.postWebService(request.url, request.param).then(function (response) {
    //        debugger;

    //        if (response.liVitals != null) {
    //            $("#Message").val('Saved !! ');//Messgae
    //            $('#Title').html('Vitals  Details Saved Successfully');//Title
    //            $("#Message").trigger("click");
    //            $scope.PatientVisitID = response.liVitals[0].PatientVisitID;
    //            $scope.initVitalsdetailslist(consultation);
    //            $scope.isSaved = 'Y';

    //            $scope.IsListVitalsdetailVisible = true;
    //            $scope.obj = null;
    //            // $scope.PatientVisitID = response.liVitals[0].PatientVisitID;
    //            $scope.PrescriptionForm.$setPristine();
    //            // $scope.PatientVisitID = response.liVitals[0].PatientVisitID;
    //            patientIdvital = $scope.PatientVisitID;
    //        }
    //        else {
    //            $scope.isSaved = 'N';
    //            $("#Message").val('Failed !! ');//Messgae
    //            $('#Title').html('Error Happened while Saving Vitals');//Title
    //            $("#Message").trigger("click");
    //        }
    //    });

    //};


    $scope.submitFormPrescript = function (isValid, consultation) {
        if ($scope.isSaved == 'Y') {
            if (isValid) {
                $scope.SavePrescript(consultation);
                $scope.PrescriptForm.$setPristine();
                $scope.isprintSaved = 'Y'
            }
            else {
                angular.forEach($scope.PrescriptForm.$error.required, function (field) {
                    field.$setDirty();
                });
            }
        }
        else {
            $("#Message").val('Failed !! ');//Messgae
            $('#Title').html('Required Vitals Details');//Title
            $("#Message").trigger("click");
            $scope.isprintSaved = 'N'

        }
        //}
    };

    $scope.SavePrescript = function (consultation) {
        consultation.PatientVisitID = $scope.PatientVisitID;
        var request = new consultationServices.SavePrescript(consultation);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;

            if (response.liVitals != null) {
                $("#Message").val('Saved !! ');//Messgae
                $('#Title').html('Precription  Details Saved Successfully');//Title
                $("#Message").trigger("click");
                $scope.obj = null;
            }
            else {
                $scope.isSaved = 'N';
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Error Happened while Saving Vitals');//Title
                $("#Message").trigger("click");
            }
        });

    };

    $scope.PrintConsulationdrug = function () {
        debugger;
        $scope.Print = true;
        $scope.obj = new consultationServices.consultationData(null);
        $scope.obj.PatientVisitID = patientIdvital;
        var request = new consultationServices.Printdetaildrug($scope.obj);
        commonService.postWebService(request.url, request.param).then(function (response) {
            $scope.PrintList = response.liprintdetails;
        });
        $scope.DatatableInitialize();
    };


    $scope.PrintS = function () {
        var printContents = document.getElementById('test').innerHTML;
        var popupWin = window.open('', 'Print-Window');
        popupWin.document.open();
        //popupWin.document.write('<html><head><link rel="stylesheet" type="text/css" href="http://localhost:63438/assets/plugins/bootstrap/css/bootstrap.min.css" /></head><body onload="window.print()">' + printContents + '</body></html>');
        popupWin.document.write('<html><head><link rel="stylesheet" type="text/css" href="../assets/plugins/bootstrap/css/bootstrap.min.css" /></head><body onload="window.print()">' + printContents + '</body></html>');
        popupWin.document.close();

        //var divToPrint = document.getElementById('test');
        //var newWin = window.open('', 'Print-Window');
        //newWin.document.open();
        ////newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');

        //newWin.document.close();
        //setTimeout(function () { newWin.close(); }, 1);
    }

    $scope.CancelPrint = function () {
        $scope.Print = false;
    }


    $scope.init();
    $scope.initdiagnosisdetails();
    $scope.initprescriptiondetails();
    $scope.initTestdetails();
    $scope.initVitalsdetails();
    $scope.myFunctionCompany = function (row, key) {
        $scope.obj = new consultationServices.consultationData(row);
        myFunctionCompany();
    }
});