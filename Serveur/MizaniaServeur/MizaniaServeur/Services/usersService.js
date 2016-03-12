(function () {
    var usersService = function ($http,$log) {
      

        var Users = function () {
            return $http.get("http://localhost:26026/api/User/getAll/")
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };
        var SearchUsers = function (UserName) {
            return $http.get("http://localhost:26026/api/User/getUserByNom/" + UserName)
            .then(function (serviceResp) {
                return serviceResp.data;
            });
        };

        var InsertUser = function (user) {
            return $http.post("http://localhost:26026/api/User/addUser", user)
            .then(function () {
                $log.info("Insert Successful");
                return;
            });
        };
        /*
        var ModifyUser = function (user) {
            return $http.put("http://localhost:26026/api/User/updateUser/" + user.id, user)
            .then(function (result) {
                $log.info("Update Successful");
                return;
            });
        };*/


        
        return {
            Users: Users,
            SearchUsers: SearchUsers,
            InsertUser: InsertUser/*,
            ModifyUser: ModifyUser*/
        };
    };
    var module = angular.module("MizaniaProjectModule");
    module.factory("usersService", ["$http", usersService]);
}());