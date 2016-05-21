(function () {
    var AllUsers = document.getElementById('AllUsers'),
        AddUser = document.getElementById('AddUser'),
        AllAwards = document.getElementById('AllAwards'),
        AddAward = document.getElementById('AddAward'),
        Role = document.getElementById('Role');

    AllUsers.onclick = function () {
        document.location.replace("/Pages/UserResults.cshtml?Role=1");
    }

    AllAwards.onclick = function () {
        document.location.replace('/Pages/AwardResults.cshtml');
    }

    AddUser.onclick = function () {
        document.location.replace('/Pages/CreateUser.cshtml');
    }

    AddAward.onclick = function () {
        document.location.replace('/Pages/CreateAward.cshtml');
    }

    Role.onclick = function () {
        document.location.replace('/Pages/Registration/RegistaredUsers.cshtml');
    }

})()