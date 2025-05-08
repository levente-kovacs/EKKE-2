<?php
    require '../config/config.php';

    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        // Adatok lementése a nézetből
        $name = $_POST['name'];
        $email = $_POST['emailAddress'];
        $address = $_POST['address'];
        $active = isset($_POST['active']) ? 1 : 0;

        // Amennyiben minden adat megérkezett, új adat felvétele az adatbázisba, ennek értékeinek beállítása
        if (isset($name) && isset($email) && isset($address) && isset($active)) {
            $stmt = $connection->prepare("INSERT INTO users (name, emailAddress, address, active) VALUES (:name, :emailAddress, :address, :active)");
            $stmt->bindParam(':name', $name);
            $stmt->bindParam(':emailAddress', $email);
            $stmt->bindParam(':address', $address);
            $stmt->bindParam(':active', $active);
            if($stmt->execute()) {
                // Sikeres mentés esetén visszairányít a home-ra
                header("Location: ../index.php?page=home");
            } else {
                // Sikertelen mentés esetén hibaüzenet
                echo 'Error: User creation failed.';
            }
        } else {
            // Hibaüzenet amennyiben nem érkezett meg minden adat
            echo 'Error: Invalid input.';
        }
    }
?>
