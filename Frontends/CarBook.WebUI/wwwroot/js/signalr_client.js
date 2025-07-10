$(document).ready(function () {



    const connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7192/carhub")
        .configureLogging(signalR.LogLevel.Information).build();








    async function start() {

        try {

            await connection.start().then(() => {
                $("#connectionId").html(`connectionId : ${connection.connectionId}`);
                console.log("hub ile bağlantı kuruldu")
            });

        }
        catch (err) {
            console.error("hub ile bağlantı kurulamadı", err);
            setTimeout(() => start(), 3000);
        }

    }

    connection.onclose(async () => {
        await start(); // bağlantı yeniden kurulana kadar bekliyorum aslında ben burda
    });

    start();




    connection.on("ReceiveBlogLikeDislike", (BlogId, UserId, UserVote) => {


        console.log("değer bu şekilde olur    " + BlogId);
        console.log("değer bu şekilde olur    " + UserId);
        console.log("değer bu şekilde olur    " + UserVote);

        const btnLike = $("#btn-like");
        const btnDislike = $("#btn-dislike");


        if (UserVote == true) {

            btnLike.removeClass("btn-outline-success").addClass("btn-success");
            btnDislike.removeClass("btn-danger").addClass("btn-outline-danger");

        }
        else if (UserVote == false) {
            btnDislike.removeClass("btn-outline-danger").addClass("btn-danger");
            btnLike.removeClass("btn-success").addClass("btn-outline-success");

        }
        else {
            btnLike.removeClass("btn-success").addClass("btn-outline-success");
            btnDislike.removeClass("btn-danger").addClass("btn-outline-danger");

        }







    });





    $("#btn-like").click(function () {

        const BlogId = parseInt(document.getElementById("blog-id").value);
        const UserId = parseInt(document.getElementById("user-id").value);
        const UserVote = true; 


        console.log(BlogId);
        console.log(UserId);
        console.log(UserVote);

        connection.invoke("BlogLikeDislike", BlogId, UserId, UserVote).catch(function (err) {
            console.error(err.toString());
        });






        

    })


    $("#btn-dislike").click(function () {

        const BlogId = parseInt(document.getElementById("blog-id").value);
        const UserId = parseInt(document.getElementById("user-id").value);
        const UserVote = false; 


        console.log(BlogId);
        console.log(UserId);
        console.log(UserVote);




        connection.invoke("BlogLikeDislike", BlogId, UserId, UserVote).catch(function (err) {
            console.error(err.toString());
        });


        

    })






   


})