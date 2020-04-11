<?php
    $con = mysqli_connect('localhost', 'root','root', 'unityaccess');

    //check connection

    if (mysqli_connect_errno())
    {
        echo "1"; // error code 1
        exit();
    }

    $username = $_POST['name'];
    $password = $_POST['password'];

    $namecheckquery = "SELECT username, salt, hash, time FROM players WHERE username ='". $username ."';";

    $namecheck = mysqli_query($con, $namecheckquery) or die("2 name check failed");
    if (mysqli_num_rows($namecheck) != 1)
    {
        echo "5: either no user with name";
        exit();
    }

    $Userinfo = mysqli_fetch_assoc($namecheck);
    $salt = $Userinfo["salt"];
    $hash = $Userinfo["hash"];

    $loginhash = crypt($password, $salt);
    if ($hash != $loginhash)
    {
        echo "6: Incorrect password";
        exit();
    }

    echo "0\t" , $Userinfo["time"];

?>