console.log("Funcionando")

function GetListProdutos() {
    $.ajax({
        url: "/produtosapi",
        method: "GET",
        success: function (data) {
            console.log(data);
        },
        error: function (data) {
            alert("erro ao trazer os produtos!")
        }
    });
}


function DeletarProduto(idProduto) {
    bootbox.confirm({
        message: "Tem certeza que deseja deletar?",
        buttons: {
            confirm: {
                label: 'Sim',
                className: 'btn-success'
            },
            cancel: {
                label: 'Não',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: "/produtosapi/" + idProduto,
                    method: "DELETE",
                    success: function (data) {
                        var linhaTabela = document.getElementById('linha_tabela_' + idProduto);
                        linhaTabela.parentNode.removeChild(linhaTabela);
                    },
                    error: function (data) {
                        bootbox.alert("erro ao deletar o produto!");
                    }
                });
            }
        }
    });
}