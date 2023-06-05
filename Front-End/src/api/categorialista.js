document.addEventListener('DOMContentLoaded', function() {
    const tableBodyElement = document.getElementById('item-table-body');

    fetch('https://localhost:7259/Categoria/ListaCategoria', { method: 'GET' })
      .then(response => response.json())
      .then(data => {
        for (let i = 0; i < data.length; i++) {
          const item = data[i];
          const itemModel = {
            Id: item.id,
            Nome: item.nome,
          };

          const row = document.createElement('tr');

          const nomeCell = document.createElement('td');
          nomeCell.textContent = item.nome;
          row.appendChild(nomeCell);

          const actionsCell = document.createElement('td');
          actionsCell.classList.add('action-buttons');
          actionsCell.classList.add('float-right');

          const editButton = document.createElement('button');
          editButton.textContent = 'Editar';
          editButton.classList.add('btn', 'btn-primary');
          editButton.style.float = 'right'; 

          editButton.addEventListener('click', function() {
            exibirModalEdicao(itemModel);
          });

          actionsCell.appendChild(editButton);

          const deleteButton = document.createElement('button');
          deleteButton.textContent = 'Apagar';
          deleteButton.classList.add('btn', 'btn-danger');
          deleteButton.style.float = 'right';
    
          deleteButton.addEventListener('click', function() {
            const itemId = {
              Id: itemModel.Id
            }
            const confirmDelete = confirm('Deseja apagar este item?');
        
            if (confirmDelete) {
                const requestOptions = {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(itemId) 
                };

                fetch('https://localhost:7259/Categoria/ApagarCategoria', requestOptions)
                  .then(response => {
                    if (response.ok) {
                          location.reload();
                    }
                    else{
                        return response.text();
                    }
                  })
                    .then(erro => {
                      if (erro) {
                         exibirMensagemErro(erro);
                      }
                    })
              }
          });

          actionsCell.appendChild(deleteButton);

          row.appendChild(actionsCell);

          tableBodyElement.appendChild(row);
        }
      })
   });

  function exibirModalEdicao(item) {
    document.getElementById('edit-nomeInput').value = item.Nome;

    const modal = new bootstrap.Modal(document.getElementById('edit-modal'));
    modal.show();
  
    const salvarButton = document.getElementById('saveButton');
    salvarButton.addEventListener('click', function() {
      const itemId = item.Id;
      salvarEdicao(itemId);
    });
  }
  
  function salvarEdicao(itemId) {
    const nome = document.getElementById('edit-nomeInput').value;
    
    const data = {
      Id: itemId,
      Nome: nome,
    };
  
    fetch('https://localhost:7259/Categoria/EditarCategoria', {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data)
    })
      .then(response => {
        if (response.ok) {
          console.log(response);
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
    }

  function exibirMensagemErro(mensagem)
  {
    Swal.fire({
      icon: 'error',
      title: 'Erro',
      text: mensagem,
    });
  }
