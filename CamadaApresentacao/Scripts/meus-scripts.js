window.onload = function () {
    pegarGuitarras();
    setInterval(pegarGuitarras, 5000);
};

function atualizarTabela() {

    var table = document.getElementById("tabelaGuitarras");

    var currentRows = document.getElementsByTagName("TR");
    
    for (var i = currentRows.length-1; i > 0; i--) {
        currentRows[i].parentNode.removeChild(currentRows[currentRows.length-1]);
    }

    for (var i = 0; i < window.guitarras.length; i++) {

        var row = table.insertRow(i+1);

        var cell0 = row.insertCell(0);
        var cell1 = row.insertCell(1);
        var cell2 = row.insertCell(2);
        var cell3 = row.insertCell(3);
        var cell4 = row.insertCell(4);
        var cell5 = row.insertCell(5);
        var cell6 = row.insertCell(6);

        cell0.innerHTML = window.guitarras[i].Nome;
        cell1.innerHTML = "R$ "+window.guitarras[i].Preco.toLocaleString('pt-BR');
        cell2.innerHTML = window.guitarras[i].Descricao;

        var data = new Date(window.guitarras[i].DataInclusao)
        var dia = data.getDate();
        dia = (dia < 10 ? "0" + dia : dia);
        var mes = data.getMonth() + 1;
        mes = (mes < 10 ? "0" + mes : mes);
        var ano = data.getFullYear();
        cell3.innerHTML = dia + '/' + (mes) + '/' + ano;

        cell4.innerHTML = window.guitarras[i].UrlImagem;
        cell5.innerHTML = "<button type=button onclick=deletarGuitarra(this) class=btn id=" + window.guitarras[i].Id + ">Deletar</button>";
    }
}

// Cria o objeto XHR.
function criarRequisicaoCORS(metodoHTTP, url) {
    var xhr = new XMLHttpRequest();
    if ("withCredentials" in xhr) {
        // XHR para Chrome/Firefox/Opera/Safari.
        xhr.open(metodoHTTP, url, true);
    } else if (typeof XDomainRequest != "undefined") {
        // XDomainRequest para IE.
        xhr = new XDomainRequest();
        xhr.open(metodoHTTP, url);
    } else {
        // CORS não suportado.
        xhr = null;
    }
    return xhr;
}

function pegarGuitarras() {
    var url = 'http://localhost:53568/api/Guitarras';

    var xhr = criarRequisicaoCORS('GET', url);
    if (!xhr) {
        console.log('CORS not supported');
    }

    xhr.onload = function () {
        var res = xhr.response;
        window.guitarras = [];
        window.guitarras = JSON.parse(res);
        atualizarTabela();
    };

    xhr.onerror = function () {
        console.log('Erro genérico na requisição.');
    };

    xhr.send();
}

function inserirGuitarra() {

    var nome = document.getElementById('nome').value;
    var preco = document.getElementById('preco').value;
    var descricao = document.getElementById('descricao').value;
    var urlImagem = document.getElementById('imagem').value;

    var camposValidos = validarCampos(nome, preco, descricao);
    
    if(camposValidos){
        var url = 'http://localhost:53568/api/Guitarras?nome=' + nome + '&preco=' +
        preco + '&descricao=' + descricao + '&urlImagem=' + urlImagem;

        var xhr = criarRequisicaoCORS('POST', url);

        if (!xhr) {
            console.log('CORS não suportado');
        }

        // Response handlers.
        xhr.onload = function () {
            var res = xhr.response;
            pegarGuitarras();
        };

        xhr.onerror = function () {
            console.log('Erro genérico na requisição.');
        };

        xhr.send();
    }    
}

function deletarGuitarra(button) {
    var botaoApertado = button;

    var url = 'http://localhost:53568/api/Guitarras?idGuitarra=' + botaoApertado.id;

    var xhr = criarRequisicaoCORS('DELETE', url);

    if (!xhr) {
        console.log('CORS não suportado');
    }

    xhr.onload = function () {
        var res = xhr.response;
        pegarGuitarras();
    };

    xhr.onerror = function () {
        console.log('Erro genérico na requisição.');
    };

    xhr.send();
}

function validarCampos(nome, preco, descricao){

    if(nome == ""){
        document.getElementById("alert").innerText = "É necessário inserir um nome.";
        document.getElementById("alert").style = "display: block; width: 50%; margin-left: 30%;"+ 
        "margin-right: 30%; text-align: center;";
        return false;
    }else if(preco == ""){
        document.getElementById("alert").innerText = "É necessário inserir um preço.";
        document.getElementById("alert").style = "display: block; width: 50%; margin-left: 30%;" +
        "margin-right: 30%; text-align: center;";
        return false;
    }else if(descricao == ""){
        document.getElementById("alert").innerText = "É necessário inserir uma descrição.";
        document.getElementById("alert").style = "display: block; width: 50%; margin-left: 30%;" +
        "margin-right: 30%; text-align: center;";
        return false;
    } else {
        document.getElementById("alert").innerText = "";
        document.getElementById("alert").style = "display: none;";
        return true;
    }
}

function formatarPreco() {
    var valorPreco = document.getElementById("preco").value;
    document.getElementById("preco").value = parseFloat(valorPreco).toFixed(2);
}