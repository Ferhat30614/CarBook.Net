$(document).ready(function () {

    //function getCookie(name) {
    //    let value = "; " + document.cookie;
    //    let parts = value.split("; " + name + "=");
    //    if (parts.length === 2) return parts.pop().split(";").shift();
    //}
    //const token = getCookie("CarBookJwt");

    //console.log("Token: ", token);  // Token'ı burada kontrol edebilirsiniz.


    const connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7192/carhub")
        .configureLogging(signalR.LogLevel.Information)
        .build();


    const currentBlogId = parseInt(document.getElementById("blog-id").value);

    const currentUserIdForMessage = parseInt(document.getElementById("currentUserId").value);
    const otherUserIdForMessage = parseInt(document.getElementById("otherUserId").value);

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


    connection.on("ReceiveBlogLikeDislike", (userVote,likeCount,disikeCount) => {


        //console.log("caller değer bu şekilde olur    " + UserVote);
        //console.log("caller  değer bu şekilde olur    " + likeCount);
        //console.log("caller  değer bu şekilde olur    " + disikeCount);

        const btnLike = $("#btn-like");
        const btnDislike = $("#btn-dislike");


        if (userVote == true) {

            btnLike.removeClass("btn-outline-success").addClass("btn-success");
            btnDislike.removeClass("btn-danger").addClass("btn-outline-danger");

        }
        else if (userVote == false) {
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

    connection.on("ReceiveBlogLikeDislikeOthers", ( blogId,likeCount, dislikeCount) => {


        //console.log("Others değer bu şekilde olur    " + LikeCount);
        //console.log("Others değer bu şekilde olur    " + DislikeCount);


        if (blogId != currentBlogId) {
            return;
        } else {
            const btnLike = $("#btn-like");
            const btnDislike = $("#btn-dislike");

            btnLike.text("👍 " + likeCount);
            btnDislike.text("👎 " + dislikeCount);

        }



    });


    $("#btn-like").click(function () {

       /* const BlogId = parseInt(document.getElementById("blog-id").value);*/
        const userId = parseInt(document.getElementById("user-id").value);
        const userVote = true; 

        if (userId == 0) {

            window.location.href = "/Login/Index";  // eğer kullanıcı oturum açmadıysa beğeni işlemi yapamaz.Burda sayfa yönlendirdim.
            return ;


        }
        
        //console.log(BlogId);
        //console.log(UserId);
        //console.log(UserVote);

        connection.invoke("BlogLikeDislike", currentBlogId, userId, userVote).catch(function (err) {
            console.error(err.toString());
        });

    })


    $("#btn-dislike").click(function () {

        /*const BlogId = parseInt(document.getElementById("blog-id").value);*/
        const userId = parseInt(document.getElementById("user-id").value);
        const userVote = false; 


        if (userId == 0) {
            window.location.href = "/Login/Index";
            return ;
        }

        //console.log(BlogId);
        //console.log(UserId);
        //console.log(UserVote);

        connection.invoke("BlogLikeDislike", currentBlogId, userId, userVote).catch(function (err) {
            console.error(err.toString());
        });


    })



})