document.addEventListener('DOMContentLoaded', function() {
  const dropdownElement = document.getElementById('categoria-dropdown');
  let categoriasArray = []; 
  
  fetch('https://localhost:7259/Categoria/ListaCategoria')
    .then(response => response.json())
    .then(data => {
      categoriasArray = data; 
      
      for (let i = 0; i < data.length; i++) {
        const categoriaItemElement = document.createElement('option');
        categoriaItemElement.textContent = categoriasArray[i].nome;
        categoriaItemElement.value = categoriasArray[i].id;
  
        dropdownElement.appendChild(categoriaItemElement);
      }
    })
});