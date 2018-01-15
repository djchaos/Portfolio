<?php
    include_once('lib/database_manager.php');
    $database = new DatabaseManager('api');

    if(isset($_POST['token']) && isset($_POST['score']))
    {
        $token = $_POST['token'];
        $score = $_POST['score'];

        $id = $database->SqlExecute("SELECT uid FROM api.token WHERE value = '{$token}'");
		
		//print_r($id);
		//die;
		if(!empty($id)){
			
			$id = $id[0]["uid"];
			

			$database->Sql("UPDATE api.user SET highscore = '{$score}' WHERE id ='{$id}'");
			
		}
        
    }

?>