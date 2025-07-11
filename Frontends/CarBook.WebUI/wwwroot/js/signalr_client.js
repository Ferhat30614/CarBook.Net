$(document).ready(function () {




    const token = getCookie("CarBookJwt");

    const connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7192/carhub",
        {
            /*withCredentials=true  // BU SATIR OLMAZSA COOKIE GİTMEZ*/
            accessTokenFactory: () => token   // burdan jwt ı gönderiyorum ve query string olarak gönderiyorum
        }).configureLogging(signalR.LogLevel.Information)
        .build();


//    "query string" nedir
//        Bir URL'nin sonuna ? ile başlayan ek parametreler kısmıdır. Örnek:
//    https://localhost:5001/carhub?access_token=eyJhbGciOi...
//    Burada:
//  ? → Query string başlatır.
//        access_token =... → Bu senin JWT token’ını taşıyan parametredir.


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




    connection.on("ReceiveBlogLikeDislike", (BlogId, UserId, UserVote,likeCount,disikeCount) => {


        console.log("değer bu şekilde olur    " + BlogId);
        console.log("değer bu şekilde olur    " + UserId);
        console.log("değer bu şekilde olur    " + UserVote);
        console.log("değer bu şekilde olur    " + likeCount);
        console.log("değer bu şekilde olur    " + disikeCount);

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


        btnLike.text("👍 " + likeCount);
        btnDislike.text("👎 " + disikeCount);





    });


    connection.on("ReceiveBlogLikeDislikeOthers", (BlogId, UserId, LikeCount, DislikeCount) => {


        console.log("Others değer bu şekilde olur    " + BlogId);
        console.log("Others değer bu şekilde olur    " + UserId);
        console.log("Others değer bu şekilde olur    " + LikeCount);
        console.log("Others değer bu şekilde olur    " + DislikeCount);

        const btnLike = $("#btn-like");
        const btnDislike = $("#btn-dislike");


       


        btnLike.text("👍 " + LikeCount);
        btnDislike.text("👎 " + DislikeCount);





    });





    $("#btn-like").click(function () {

        const BlogId = parseInt(document.getElementById("blog-id").value);
        const UserId = parseInt(document.getElementById("user-id").value);

        if (UserId == 0) {

            window.location.href = "/Login/Index";  // eğer kullanıcı oturum açmadıysa beğeni işlemi yapamaz.Burda sayfa yönlendirdim.


        }
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


        if (UserId == 0) {
            window.location.href = "/Login/Index";
        }


        console.log(BlogId);
        console.log(UserId);
        console.log(UserVote);




        connection.invoke("BlogLikeDislike", BlogId, UserId, UserVote).catch(function (err) {
            console.error(err.toString());
        });


        

    })



})