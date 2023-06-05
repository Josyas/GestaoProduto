document.addEventListener('DOMContentLoaded', function() {
    const formElement = document.querySelector('form');
  
    formElement.addEventListener('submit', function(event) {
      event.preventDefault(); 

      const nome = document.getElementById('nomeInput').value;
        
      const categoriaData = {
        Nome: nome,
      };
  
      const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(categoriaData)
      };
        fetch('https://localhost:7259/Categoria/Cadastrar', requestOptions)
        .then(response => {
          if (response.ok) {
            location.reload();
          } else {
            return response.text(); 
          }
        })
        .then(erro => {
          if (erro) {
            exibirMensagemErro(erro);
          }
        })
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
