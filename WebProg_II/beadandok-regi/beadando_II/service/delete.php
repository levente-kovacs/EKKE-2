<?php
    require '../config.php';

    $user = json_decode(file_get_contents("php://input"));

    if (isset($user->id)) {
        $stmt = $connection->prepare("DELETE FROM users WHERE id = :id");
        $stmt->bindParam(':id', $user->id);
        if($stmt->execute()) {
            echo json_encode(['message' => 'User deleted successfully.']);
        } else {
            echo json_encode(['message' => 'User deletion failed.']);
        }
    } else {
        echo json_encode(['message' => 'Invalid input.']);
    }
?>
