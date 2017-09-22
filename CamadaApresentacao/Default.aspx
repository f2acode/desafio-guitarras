<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CamadaApresentacao._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="/Scripts/meus-scripts.js"></script>

    <div class="jumbotron">
        <h1 style="text-align: center;">Sistema de guitarras</h1> 
    </div>

    <h1 style="text-align: center">Registre uma guitarra</h1>
    
    <div class="wrapper-div">
    <div class="input-group">
    <span class="input-group-addon">Nome:</span>
    <input type="text" class="form-control" id="nome" placeholder="Insira um nome" maxlength=400
      aria-label="Insira um nome" aria-describedby="basic-addon1">
    </div>
    <br>
    <div class="input-group">
    <span class="input-group-addon">Preço ($)</span>
    <input type="number" id="preco" class="form-control" onblur="formatarPreco()" step="0.01" min=0
        placeholder="Insira um preço" aria-label="Amount (to the nearest dollar)">
    </div>
    <br>
    <div class="input-group">
    <span class="input-group-addon">Descrição:</span>
    <input type="text" class="form-control" id="descricao" placeholder="Insira uma descrição" 
        maxlength=1000 aria-label="Amount (to the nearest dollar)">
    </div>
    <br>
    <div class="input-group">
    <span class="input-group-addon">URL(opcional):</span>
    <input type="text" id="imagem" class="form-control" placeholder="Insira uma URL" maxlength=512
        aria-describedby="basic-addon3">
    </div>
    </div>

    <button type="button" class="btn btn-primary btn-lg" style="margin-left: 60px; margin-bottom: 20px" 
        onclick="inserirGuitarra();">Inserir guitarra</button>

    <div id="alert" class="alert alert-danger" style="display: none;" role="alert"> </div>

    <h1 style="text-align: center">Tabela de guitarras cadastradas</h1>

    <table id="tabelaGuitarras" class="table table-bordred table-striped">
    <thead>
    <th>Nome</th>
    <th>Preço</th>
    <th>Descrição</th>
    <th>Data de inclusão</th>
    <th>Url da imagem</th>

    <th>Edit</th>              
    <th>Delete</th>
    </thead>

    <tbody></tbody>
    </table>

</asp:Content>

