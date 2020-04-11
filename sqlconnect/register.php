<?php

    $con = mysqli_connect('localhost', 'root','root', 'unityaccess');

    //check connection

    if (mysqli_connect_errno())
    {
        echo "1"; // error code 1
        exit();
    }

    $username = $_POST["name"];
    $password = $_POST["password"];

    $namecheckquery = "SELECT username FROM players WHERE username ='". $username ."';";

    $namecheck = mysqli_query($con, $namecheckquery) or die("2 name check failed");

    if (mysqli_num_rows($namecheck) > 0)
    {
        echo  " 3 name already exists";
        exit();
    }

    $salt = "\$5\$round=5000\$" . "aurora" . $username . "\$";
    $hash = crypt($password, $salt);
    $insertuserquery = "INSERT INTO players (username, hash ,salt) VALUES ('". $username ."', '". $hash ."', '". $salt ."');";
    mysqli_query($con, $insertuserquery) or die("query failed");

    echo("0");



?>