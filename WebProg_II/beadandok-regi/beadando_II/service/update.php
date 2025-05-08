<?php
    require '../config.php';

    $user = json_decode(file_get_contents("php://input"));

    if (isset($user->id) && isset($user->name) && isset($user->emailAddress) && isset($user->address) && isset($user->active)) {
        $stmt = $connection->prepare("UPDATE users SET name = :name, emailAddress = :emailAddress, address = :address, active = :active WHERE id = :id");
        $stmt->bindParam(':id', $user->id);
        $stmt->bindParam(':name', $user->name);
        $stmt->bindParam(':emailAddress', $user->emailAddress);
        $stmt->bindParam(':address', $user->address);
        $stmt->bindParam(':active', $user->active);
        if($stmt->execute()) {
            echo json_encode(['message' => 'User updated successfully.']);
        } else {
            echo json_encode(['message' => 'User update failed.']);
        }
    } else {
        echo json_encode(['message' => 'Invalid input.']);
    }
?>
