(function () {
    var UserBDController = function ($scope,usersService,$log) {
        var Users = function (data) {
            $scope.Users = data;
        };

        /*$scope.init = function () {
            usersService.singleProject($routeParams.projectID).then(singleProject, errorDetails);
        };*/
        $scope.SearchUsers = function (UserName) {
            usersService.SearchUsers(UserName)
            .then(Users, errorDetails);
            $log.info('Found user which contains - ' + UserName);
        };

        var user = {
            id: 5,
            nom: null,
            prenom: null,
            nomDeCompte:'SissoumaBNP',
            roleUtilisateur: 'createur',
            idPorteFeuille : 1
        };
        $scope.user = user;

        usersService.Users().then(Users, errorDetails);

        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };
        $scope.InsertUser = function (user) {
            usersService.InsertUser(user).then(usersService.Users().then(Users, errorDetails));

        };
       /* $scope.ModifyUser = function (existingUser) {
            $log.info(existingUser);
            usersService.modifyUser(existingUser).then(usersService.Users().then(Users, errorDetails));
        };*/

        $scope.Title = "Users";
        $scope.UserName = null;
    };
    app.controller("UserBDController", ["$scope", "usersService", "$log", UserBDController]);
}());