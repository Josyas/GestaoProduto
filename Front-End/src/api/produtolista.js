document.addEventListener('DOMContentLoaded', function() {
    const tableBodyElement = document.getElementById('item-table-body');

    fetch('https://localhost:7259/Produto/ListaProduto', { method: 'GET' })
      .then(response => response.json())
      .then(data => {
        for (let i = 0; i < data.length; i++) {
          const item = data[i];
          const itemModel = {
            Id: item.id,
            Nome: item.nome,
            Codigo: item.codigo,
            DataFabricacao: item.dataFabricacao,
            DataVencimento: item.dataVencimento,
            Valor: item.valor,
            Categoria: item.categoria.nome
          };

          const row = document.createElement('tr');

          const nomeCell = document.createElement('td');
          nomeCell.textContent = item.nome;
          row.appendChild(nomeCell);

          const codigoCell = document.createElement('td');
          codigoCell.textContent = item.codigo;
          row.appendChild(codigoCell);

          const dataFabricacaoCell = document.createElement('td');
          dataFabricacaoCell.textContent = item.dataFabricacao.split('T')[0];
          row.appendChild(dataFabricacaoCell);
          
          const dataVencimentoCell = document.createElement('td');
          dataVencimentoCell.textContent = item.dataVencimento.split('T')[0];
          row.appendChild(dataVencimentoCell);

          const valorCell = document.createElement('td');
          valorCell.textContent = item.valor;
          row.appendChild(valorCell);

          const categoriaCell = document.createElement('td');
          categoriaCell.textContent = item.categoria.nome;
          row.appendChild(categoriaCell);

          const actionsCell = document.createElement('td');
          actionsCell.classList.add('action-buttons');

          const editButton = document.createElement('button');
          editButton.textContent = 'Editar';
          editButton.classList.add('btn', 'btn-primary');

          editButton.addEventListener('click', function() {
            exibirModalEdicao(itemModel);
          });

          actionsCell.appendChild(editButton);

          const deleteButton = document.createElement('button');
          deleteButton.textContent = 'Apagar';
          deleteButton.classList.add('btn', 'btn-danger');
          deleteButton.addEventListener('click', function() {
            const itemId = {
              Id: itemModel.Id
            }

            const confirmDelete = confirm('Quer apagar este item?');
        
            if (confirmDelete) {
                const requestOptions = {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(itemId) 
                };
  
                fetch('https://localhost:7259/Produto/Apagar', requestOptions)
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
    document.getElementById('edit-codigoInput').value = item.Codigo;
    document.getElementById('edit-dataFabricacaoInput').value = item.DataFabricacao.split('T')[0];
    document.getElementById('edit-dataVencimentoInput').value = item.DataVencimento.split('T')[0];
    document.getElementById('edit-valorInput').value = item.Valor;
    document.getElementById('categoria-dropdown').value;
    
    const modal = new bootstrap.Modal(document.getElementById('edit-modal'));
    modal.show();
    
    const salvarButton = document.getElementById('saveButton');
    salvarButton.addEventListener('click', function() {
        salvarEdicao(item);
    });
  }
  
  function salvarEdicao(item) {
    const nome = document.getElementById('edit-nomeInput').value;
    const codigo = document.getElementById('edit-codigoInput').value;
    const dataFabricacao = document.getElementById('edit-dataFabricacaoInput').value;
    const dataVendimento = document.getElementById('edit-dataVencimentoInput').value;
    const valor = document.getElementById('edit-valorInput').value;
    const idCategoria = document.getElementById('categoria-dropdown').value;
    
    const data = {
      Id: item.Id,
      Nome: nome,
      Codigo: codigo,
      DataFabricacao: dataFabricacao,
      DataVencimento: dataVendimento,
      Valor: valor,
      IdCategoria: idCategoria
    };
  
    fetch('https://localhost:7259/Produto/Editar', {
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