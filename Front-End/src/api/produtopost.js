document.addEventListener('DOMContentLoaded', function() {
    const formElement = document.querySelector('form');

    formElement.addEventListener('submit', function(event) {
      event.preventDefault(); 

      const nome = document.getElementById('nomeInput').value;
      const codigo = document.getElementById('codigoInput').value;
      const dataFabricacao = document.getElementById('dataFabricacaoInput').value;
      const dataVencimento = document.getElementById('dataVencimentoInput').value;
      const valor = document.getElementById('valorInput').value;
      const idCategoria = document.getElementById('categoria-dropdown').value;
        
      const produtoData = {
        Nome: nome,
        Codigo: codigo,
        DataFabricacao: dataFabricacao,
        DataVencimento: dataVencimento,
        Valor: valor,
        IdCategoria: parseInt(idCategoria)
      };
  
      const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(produtoData)
      };
        fetch('https://localhost:7259/Produto/Cadastrar', requestOptions)
        .then(response => {
          if (response.ok) {
            location.reload();
          } else {
            return response.text(); 
          }
        })
        .then(erro => {
          if (erro) {
            console.log(erro);
            exibirMensagemErro(erro);
          }
        })
        .catch(error => {
          console.error('Erro ao criar o produto:', error);
        });
    });
  });

  function exibirMensagemErro(mensagem)
  {
    Swal.fire({
      icon: 'error',
      title: 'Erro',
      text: mensagem,
    });
  }
