<?php


$con = mysqli_connect('localhost', 'root','root', 'unityaccess');

    //check connection

    if (mysqli_connect_errno())
    {
        echo "1"; // error code 1
        exit();
    }

 
    
    $username = $_POST["name"];
    $newtime = $_POST["time"];

   

    
    $namecheckquery = "SELECT username, salt, hash, time FROM players WHERE username ='". $username ."';";


    $namecheck = mysqli_query($con, $namecheckquery) or die("2 name check failed");
    if (mysqli_num_rows($namecheck) != 1)
    {
        echo "5: either no user with name";
        exit();
    }



    
    $updatequery = "UPDATE players SET time='$newtime' WHERE username='$username'";

   
    mysqli_query($con, $updatequery) or die("7: save query failed");

 

    

    echo "0";
    
?>