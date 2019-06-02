var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope, $http) {

    $scope.selectedTrainee;
    $scope.addTrainee = { TraineeId: 0, TraineeName: '' };

    $scope.getTrainees = function () {
        $http.get("http://localhost:60563/api/trainees")
            .then(function (response) { $scope.trainees = response.data; });
    };

    $scope.createTrainee = function () {
        $http.post("http://localhost:60563/api/trainees", $scope.addTrainee)
            .then(function (response) {
                alert("Trainee has been created");

                $scope.addTrainee = undefined;
                $scope.getTrainees();
            });
    };

    $scope.deleteTrainee = function (traineeId) {
        $http.delete("http://localhost:60563/api/trainees/" + traineeId)
            .then(function (response) {
                alert("Trainee has been deleted");

                $scope.getTrainees();
            });
    };

    $scope.updateTrainee = function () {
        $http.put("http://localhost:60563/api/trainees/" + $scope.selectedTrainee.TraineeId, $scope.selectedTrainee)
            .then(function (response) {
                alert("Trainee has been updated");

                $scope.selectedTrainee = undefined;
                $scope.getTrainees();
            });
    };

    $scope.selectTrainee = function (trainee) {
        $scope.selectedTrainee = { TraineeId: trainee.TraineeId, TraineeName: trainee.TraineeName };        
    };

    $scope.getTrainees();
});