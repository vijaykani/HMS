﻿commonApp.directive('ngUploadChange', function () {
    return {
        scope: {
            ngUploadChange: "&"
        },
        link: function ($scope, $element, $attrs) {
            $element.on("change", function (event) {
                $scope.$apply(function () {
                    $scope.ngUploadChange({ $event: event })
                })
            })
            $scope.$on("$destroy", function () {
                $element.off();
            });
        }
    }
});

commonApp.directive('validImage', function () {
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, ngModel) {
            var validFormats = ['jpg', 'jpeg', 'png'];
            elem.bind('change', function () {
                validImage(false);
                scope.$apply(function () {
                    ngModel.$render();
                });
            });
            ngModel.$render = function () {
                ngModel.$setViewValue(elem.val());
            };
            function validImage(bool) {
                ngModel.$setValidity('extension', bool);
            }
            ngModel.$parsers.push(function (value) {
                var ext = value.substr(value.lastIndexOf('.') + 1);
                if (ext == '') return;
                if (validFormats.indexOf(ext) == -1) {
                    return value;
                }
                validImage(true);
                return value;
            });
        }
    };
});

commonApp.directive('validFile', function () {
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, ngModel) {
            var validFormats = ['jpg', 'jpeg', 'png'];
            elem.bind('change', function () {
                validImage(false);
                scope.$apply(function () {
                    ngModel.$render();
                });
            });
            ngModel.$render = function () {
                ngModel.$setViewValue(elem.val());
            };
            function validImage(bool) {
                ngModel.$setValidity('extension', bool);
            }
            ngModel.$parsers.push(function (value) {
                var ext = value.substr(value.lastIndexOf('.') + 1);
                if (ext == '') return;
                if (validFormats.indexOf(ext) == -1) {
                    return value;
                }
                validImage(true);
                return value;
            });
        }
    };
});

commonApp.directive('numericValidation', function () {
    return {
        restrict: "A",
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                if (text) {
                    var transformedInput = text.toString().replace(/[^0-9]/g, '');

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

//commonApp.directive('validateEmail', function () {
//    var Email_Exp = /^[_a-zA-Z0-9]+(\.[_a-zA-Z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$/;
//    return {
//        require: 'ngModel',
//        restrict: '',
//        link: function (scope, elm, attrs, ctrl) {
//            // only apply the validator if ngModel is present and Angular has added the email validator
//            if (ctrl && ctrl.$validators.email) {
//                ctrl.$validators.email = function (modelValue) {
//                    if (modelValue) {
//                        var emailArr = modelValue.split(';').filter(function (n) { return n });
//                        var isValid = true;
//                        angular.forEach(emailArr, function (email) {
//                            isValid = isValid && Email_Exp.test(email.trim());
//                        });
//                        return isValid;
//                    }
//                }
//            }
//        }
//    };
//});

commonApp.directive('validateEmail', function () {
    var EMAIL_REGEXP = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    return {
        require: 'ngModel',
        restrict: '',
        link: function (scope, elm, attrs, ctrl) {
            // only apply the validator if ngModel is present and Angular has added the email validator
            if (ctrl && ctrl.$validators.email) {

                // this will overwrite the default Angular email validator
                ctrl.$validators.email = function (modelValue) {
                    return ctrl.$isEmpty(modelValue) || EMAIL_REGEXP.test(modelValue);
                };
            }
        }
    };
});

commonApp.directive('alphabetsOnly', function () {
    return {
        require: 'ngModel',
        scope: {
            regex: '@alphabetsOnly',
            with: '@with'
        },
        link: function (scope, element, attrs, model) {
            model.$parsers.push(function (val) {
                if (!val) { return; }
                var regex = new RegExp(scope.regex);
                var replaced = val.replace(regex, scope.with);
                if (replaced !== val) {
                    model.$setViewValue(replaced);
                    model.$render();
                }
                return replaced;
            });
        }
    };
});

commonApp.directive('datepicker', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        compile: function () {

            return {
                pre: function (scope, element, attrs, ngModelCtrl) {
                    var format, dateObj;
                    format = (!attrs.dpFormat) ? 'mm/yyyy' : attrs.dpFormat;
                    if (!attrs.initDate && !attrs.dpFormat) {
                        // If there is no initDate attribute than we will get todays date as the default
                        dateObj = new Date();
                        scope[attrs.ngModel] = (dateObj.getMonth() + 1) + '/' + dateObj.getFullYear();
                    } else if (!attrs.initDate) {
                        // Otherwise set as the init date
                        scope[attrs.ngModel] = attrs.initDate;
                    }
                    // Initialize the date-picker
                    $(element).datepicker({
                        format: format,
                        orientation: 'bottom',
                        viewMode: "months",
                        minViewMode: "months",
                        endDate: '+0m'
                    }).on('changeDate', function (ev) {
                        // To me this looks cleaner than adding $apply(); after everything.
                        scope.$apply(function () {
                            ngModelCtrl.$setViewValue(ev.format(format));
                        });
                    });
                }
            }
        }
    }
});

commonApp.directive('datepickerddmm', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        compile: function () {

            return {
                pre: function (scope, element, attrs, ngModelCtrl) {
                    var format, dateObj;
                    format = (!attrs.dpFormat) ? 'dd/mm/yyyy' : attrs.dpFormat;
                    if (!attrs.initDate && !attrs.dpFormat) {
                        // If there is no initDate attribute than we will get todays date as the default
                        dateObj = new Date();
                        scope[attrs.ngModel] = (dateObj.getMonth() + 1) + '/' + dateObj.getFullYear();
                    } else if (!attrs.initDate) {
                        // Otherwise set as the init date
                        scope[attrs.ngModel] = attrs.initDate;
                    }
                    // Initialize the date-picker
                    $(element).datepicker({
                        format: format,
                        orientation: 'bottom',
                        endDate: '+0m'
                    }).on('changeDate', function (ev) {
                        // To me this looks cleaner than adding $apply(); after everything.
                        scope.$apply(function () {
                            ngModelCtrl.$setViewValue(ev.format(format));
                        });
                    });
                }
            }
        }
    }
});

commonApp.directive('numbersOnly', function () {
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

commonApp.directive('decimalOnly', function () {
    return {
        require: '?ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            if (!ngModelCtrl) {
                return;
            }

            ngModelCtrl.$parsers.push(function (val) {
                if (angular.isUndefined(val)) {
                    var val = '';
                }

                var clean = val.replace(/[^-0-9\.]/g, '');
                var negativeCheck = clean.split('-');
                var decimalCheck = clean.split('.');
                if (!angular.isUndefined(negativeCheck[1])) {
                    negativeCheck[1] = negativeCheck[1].slice(0, negativeCheck[1].length);
                    clean = negativeCheck[0] + '-' + negativeCheck[1];
                    if (negativeCheck[0].length > 0) {
                        clean = negativeCheck[0];
                    }

                }

                if (!angular.isUndefined(decimalCheck[1])) {
                    decimalCheck[1] = decimalCheck[1].slice(0, 2);
                    clean = decimalCheck[0] + '.' + decimalCheck[1];
                }

                if (val !== clean) {
                    ngModelCtrl.$setViewValue(clean);
                    ngModelCtrl.$render();
                }
                return clean;
            });

            element.bind('keypress', function (event) {
                if (event.keyCode === 32) {
                    event.preventDefault();
                }
            });
        }
    };
});

//commonApp.directive('decimalOnly', function () {
//    return {
//        require: 'ngModel',
//        link: function (scope) {
//            scope.$watch('wks.number', function (newValue, oldValue) {
//                var arr = String(newValue).split("");
//                if (arr.length === 0) return;
//                if (arr.length === 1 && (arr[0] == '-' || arr[0] === '.')) return;
//                if (arr.length === 2 && newValue === '-.') return;
//                if (isNaN(newValue)) {
//                    scope.wks.number = oldValue;
//                }
//            });
//        }
//    };
//});