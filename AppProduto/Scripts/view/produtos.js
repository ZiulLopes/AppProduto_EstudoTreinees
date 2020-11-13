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



function ChecarCampos() {
    var txtNome = document.getElementById('Name');
    var txtDescricao = document.getElementById('Description');
    var txtTipo = document.getElementById('Type');
    var txtDataCadastro = document.getElementById('DateAdd');

    if (txtNome.value == '' || txtDescricao.value == '' ||
        txtTipo.value == 0 || txtDataCadastro.value == '')
        return false;

    return true;
}

function HabilitaBotao() {
    console.log('Function HabilitaBotao');
    var btnSalvar = document.querySelector('.meuBtnSalvar');
    if (btnSalvar.disabled == true && ChecarCampos() == true) {
        btnSalvar.disabled = false;
    }
    else if (btnSalvar.disabled == false && ChecarCampos() == false) {
        btnSalvar.disabled = true;
    }
}


function mascaraData(val) {
    var pass = val.value;
    var expr = /[0123456789]/;

    for (i = 0; i < pass.length; i++) {
        // charAt -> retorna o caractere posicionado no índice especificado
        var lchar = val.value.charAt(i);
        var nchar = val.value.charAt(i + 1);

        if (i == 0) {
            // search -> retorna um valor inteiro, indicando a posição do inicio da primeira
            // ocorrência de expReg dentro de instStr. Se nenhuma ocorrencia for encontrada o método retornara -1
            // instStr.search(expReg);
            if ((lchar.search(expr) != 0) || (lchar > 3)) {
                val.value = "";
            }

        } else if (i == 1) {

            if (lchar.search(expr) != 0) {
                // substring(indice1,indice2)
                // indice1, indice2 -> será usado para delimitar a string
                var tst1 = val.value.substring(0, (i));
                val.value = tst1;
                continue;
            }

            if ((nchar != '/') && (nchar != '')) {
                var tst1 = val.value.substring(0, (i) + 1);

                if (nchar.search(expr) != 0)
                    var tst2 = val.value.substring(i + 2, pass.length);
                else
                    var tst2 = val.value.substring(i + 1, pass.length);

                val.value = tst1 + '/' + tst2;
            }

        } else if (i == 4) {

            if (lchar.search(expr) != 0) {
                var tst1 = val.value.substring(0, (i));
                val.value = tst1;
                continue;
            }

            if ((nchar != '/') && (nchar != '')) {
                var tst1 = val.value.substring(0, (i) + 1);

                if (nchar.search(expr) != 0)
                    var tst2 = val.value.substring(i + 2, pass.length);
                else
                    var tst2 = val.value.substring(i + 1, pass.length);

                val.value = tst1 + '/' + tst2;
            }
        }

        if (i >= 6) {
            if (lchar.search(expr) != 0) {
                var tst1 = val.value.substring(0, (i));
                val.value = tst1;
            }
        }
    }

    if (pass.length > 10)
        val.value = val.value.substring(0, 10);
    return true;
}