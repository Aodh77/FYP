<?php


$con = mysqli_connect('localhost', 'root','root', 'unityaccess');

    //check connection

    if (mysqli_connect_errno())
    {
        echo "1"; // error code 1
        exit();
    }


    $timequery = "SELECT * FROM players ORDER by time = 0, time  LIMIT 10";


    $result = mysqli_query($con,$timequery) or die('Query failed');

    $num_results = mysqli_num_rows($result);

    for($i = 0; $i < $num_results; $i++)
        {
             $row = mysqli_fetch_array($result);
             echo $row['username'] . ";" . $row['time'] . ";";
        }



?>