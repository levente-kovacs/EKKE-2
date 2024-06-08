<?php
    if (isset($_GET['id'])) {
        $users = get_data($api_url);
        foreach ($users as $user) {
            if ($user['id'] == $_GET['id']) {
                $current_user = $user;
                break;
            }
        }
    }    

    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        $users = get_data($api_url);
        $edited_user = [
            'id' => $_POST['id'],
            'name' => $_POST['name'],
            'emailAddress' => $_POST['emailAddress'],
            'address' => $_POST['address'],
            'active' => isset($_POST['active']) ? true : false
        ];
        save_data($api_url . '/' . $_POST['id'], $edited_user, 'PUT');
        header("Location: index.php?page=home");
        exit();
    }
?>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Edit user</title>
    <link rel="stylesheet" href="assets/font-awesome-4.7.0/css/font-awesome.min.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="css/bg.css">
    <link rel="stylesheet" type="text/css" href="css/style.css">
</head>
<body>
<div class="background"></div>
    <h1 class="title display-5 text-center m-5 text-white">
        <i class="fa fa-user-circle-o" aria-hidden="true"></i><br>
        Edit user
    </h1>
    <main class="col-lg-6 col-10">
        <form class="form-control p-4 needs-validation" method="post" action="index.php?page=edit" novalidate>
            <div class="mb-3">
                <label for="id" class="form-label">Id</label>
                <input type="number" class="form-control" id="id" name="id" value="<?php echo $current_user['id']; ?>" readonly>
            </div>
            <div class="mb-3">
                <label for="name" class="form-label">Name</label>
                <input type="text" class="form-control" id="name" name="name" value="<?php echo $current_user['name']; ?>"
                    pattern="^[A-ZÜŰÖŐÓÚÁÉÍ][a-zöőüűóúéáíA-ZÜŰÖŐÓÚÁÉÍ]{3,}(?: [A-ZÜŰÖŐÓÚÁÉÍ][a-zöőüűóúéáíA-ZÜŰÖŐÓÚÁÉÍ]*){0,2}$" required>
                <div class="invalid-feedback">Please enter a valid name.</div>
            </div>
            <div class="mb-3">
                <label for="emailAddress" class="form-label">Email address</label>
                <input type="email" class="form-control" id="emailAddress" name="emailAddress" aria-describedby="emailHelp" value="<?php echo $current_user['emailAddress']; ?>" required>
                <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
                <div class="invalid-feedback">Please enter a valid email address.</div>
            </div>
            <div class="mb-4">
                <label for="address" class="form-label">Address</label>
                <input type="text" class="form-control" id="address" name="address" value="<?php echo $current_user['address']; ?>" required>
                <div class="invalid-feedback">Please enter an address.</div>
            </div>
            <div class="d-flex flex-column align-items-center justify-content-center">
                <div class="mb-4 form-check">
                    <input type="checkbox" class="form-check-input" id="active" name="active" <?php if ($current_user['active']) echo 'checked'; ?>>
                    <label class="form-check-label" for="active">Active</label>
                </div>
                <button type="submit" class="btn btn-outline-success col-8"><i class="fa fa-save" aria-hidden="true"></i></button>
            </div>
        </form>
    </main>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <script src="../assets/js/bootstrap.formvalidation.js"></script>
</body>
</html>