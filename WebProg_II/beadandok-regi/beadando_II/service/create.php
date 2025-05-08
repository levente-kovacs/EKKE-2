<?php
    require '../config/config.php';

    $user = json_decode(file_get_contents("php://input"));

    if (isset($user->name) && isset($user->emailAddress) && isset($user->address) && isset($user->active)) {
        $stmt = $connection->prepare("INSERT INTO users (name, emailAddress, address, active) VALUES (:name, :emailAddress, :address, :active)");
        $stmt->bindParam(':name', $user->name);
        $stmt->bindParam(':emailAddress', $user->emailAddress);
        $stmt->bindParam(':address', $user->address);
        $stmt->bindParam(':active', $user->active);
        if($stmt->execute()) {
            echo json_encode(['message' => 'User created successfully.']);
        } else {
            echo json_encode(['message' => 'User creation failed.']);
        }
    } else {
        echo json_encode(['message' => 'Invalid input.']);
    }
?>
