
$(document).ready(function () {
    $("#password-view").on("click", function () {
        var type = $("#password").attr('type') === "text" ? "password" : "text";
        $("#password").prop('type', type);
    });

    $("#confirm-view").on("click", function () {
        var type = $("#confirm").attr('type') == "text" ? "password" : "text";
        $("#confirm").prop('type', type);
    });

    $("#password-view-login").on("click", function () {
        var type = $("#login-password").attr('type') == "text" ? "password" : "text";
        $("#login-password").prop('type', type);
    });
    var userName = $('#get-user-name').html();
    function GetUserBalance(){
        $.ajax({
            method: "GET",
            url: 'https://localhost:5001/balance/getBalance',
            data: { userName: userName },
            contentType: 'application/json',
            success: function (res) {
                console.log(res)
                $('#user-balance').html(`Ваш баланс: ${res} `);
            }
        });
    }
    GetUserBalance();
    function updateUserBalance(){
        $.ajax({
            method: "GET",
            url: 'https://localhost:5001/balance/getBalance',
            data: { userName: userName },
            contentType: 'application/json',
            success: function (res) {
                console.log(res)
                $('#balance-title').html(`Ваш баланс: ${res} `);
                $('#user-balance').html(`Ваш баланс: ${res} `);
            }
        });
    }
    $('#form-balance').submit(function (e) {
        e.preventDefault();
        var userId = $('#user-id').val();
        var balanceUp = $('#balance-data').val();
        var balance = $('#balance-up');
        var setBalance = { userId: userId, balance: balanceUp }
        $.ajax({
            method: "POST",
            url: 'https://localhost:5001/balance/upbalance',
            data: JSON.stringify(setBalance),
            contentType: 'application/json',
            success: function (res) {
                if (res === 200) {
                    console.log(res)
                    balance.attr('data-content', `Баланс успешно пополнен на сумму: ${balanceUp}`);
                    balance.popover('show')
                }
                else {
                    balance.attr('data-content', `Введены некорректные данные`);
                    balance.popover('show');
                }
            }
        });
    });
    $('#form-balance-user').submit(function (e) {
        e.preventDefault();
        var userId = $('#user-id').val();
        var balanceUp = $('#balance-data').val();
        var formInformer = $('#balance-up');
        console.log(userId);
        console.log(balanceUp);
        var setBalance = {
            userId: userId,
            balance: balanceUp
        }
        $.ajax({
            method: "POST",
            url: 'https://localhost:5001/balance/usertransaction',
            data: JSON.stringify(setBalance),
            contentType: 'application/json',
            success: function (res) {
                switch (res) {
                    case 200:
                        formInformer.attr('data-content', `Баланс пользователя: ${userId} пополнен на сумму: ${balanceUp}`);
                        formInformer.popover('show');
                        break;
                    case 406:
                        formInformer.attr('data-content', `Недостаточно средств`);
                        formInformer.popover('show')
                        break;
                    case 404:
                        formInformer.attr('data-content', `пользователь не найден`);
                        formInformer.popover('show');
                        break;
                    case 407:
                        formInformer.attr('data-content', `нельзя пополнить баланс самому себе`);
                        formInformer.popover('show');
                        break;
                    case 409:
                        formInformer.attr('data-content', `введена отрицательная сумма`);
                        formInformer.popover('show');
                        break;
                    default:
                        formInformer.attr('data-content', `Введены некорректные данные`);
                        formInformer.popover('show');
                        break;
                }
                updateUserBalance();
            }
        });
    });

    $('#payment-form').submit(function (e) {
        e.preventDefault();
        var providerId = $('#provider').val();
        var props = $('#props').val();
        var paymentSum = $('#payment-sum').val();
        var paymentInformer = $('#payment-button');
        var addPaymentViewModel = {
            providerId: providerId,
            sum: paymentSum,
            propsId: props
        }
        console.log(addPaymentViewModel);
        $.ajax({
            method: "POST",
            url: 'https://localhost:5001/payments/newpayment',
            data: JSON.stringify(addPaymentViewModel),
            contentType: 'application/json',
            success: function (res) {
                switch (res) {
                    case 200:
                        paymentInformer.attr('data-content', `Платеж  совершен на сумму: ${paymentSum}`);
                        paymentInformer.popover('show');
                        break;
                    case 406:
                        paymentInformer.attr('data-content', `Недостаточно средств`);
                        paymentInformer.popover('show')
                        break;
                    case 404:
                        paymentInformer.attr('data-content', `пользователь не найден`);
                        paymentInformer.popover('show');
                        break;
                    case 407:
                        paymentInformer.attr('data-content', `нельзя пополнить баланс самому себе`);
                        paymentInformer.popover('show');
                        break;
                    case 409:
                        paymentInformer.attr('data-content', `введена отрицательная сумма`);
                        paymentInformer.popover('show');
                        break;
                    default:
                        paymentInformer.attr('data-content', `Введены некорректные данные`);
                        paymentInformer.popover('show');
                        break;
                }
                updateUserBalance();
            }
        });

    });
    // $('#filtration-form').submit(function (e) {
    //     e.preventDefault();
    //   
    //     var dateTo = $('#date-to').val();
    //     var dateFrom = $('#date-from').val();
    //   
    //     var filtrationViewModel = {
    //         dateTo: dateTo,
    //         dateFrom: dateFrom,
    //     }
    //     console.log(filtrationViewModel);
    //     $.ajax({
    //         method: "GET",
    //         url: 'https://localhost:5001/transactions/filtration',
    //         data: {dateFrom: dateFrom, dateTo: dateTo},
    //         contentType: 'application/json',
    //         success: function (res) {
    //             console.log(res);
    //            $('#table-body').empty().append(res);
    //             }

        });

    });

})