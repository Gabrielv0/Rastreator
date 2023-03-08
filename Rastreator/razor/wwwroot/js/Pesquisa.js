const pesquisa = document.querySelector("#ok")

const listaTudo = document.querySelector("#listarTodos")

const produtoPesquisa = document.querySelector("#produtoPesquisa")

const lista = document.querySelector('#lista')

const teste = document.getElementById('teste')

const email = document.querySelector("#email").value

if (pesquisa) {

    pesquisa.addEventListener('click', () => {
        pesquisaProduto(produtoPesquisa.value);
    })
}

if (listaTudo) {

    listaTudo.addEventListener('click', () => {
        listaTodos();
    })
}


function listaTodos() {
    fetch(`https://localhost:44384/api/Users?email=${email}`)
    
        .then(resp => {
            return resp.json();
        })
        .then(data => {
            if (data.length < 1) {
                limpaBusca(lista);
                const erro = `<h4>Nenhum produto foi encontrado...</h4>`;
                lista.insertAdjacentHTML('beforeend', erro);
                throw new Error('Informe o produto no campo de busca')
            }

            else {
                console.log(data);
                limpaBusca(lista);
                data.forEach(rastreio => {
                    const nome = `<h4>Nome do Produto: ${rastreio.nomeDoProduto}</h4>`;
                    const empresa = `<p>Empresa: ${rastreio.empresa}</p>`;
                    const codigoRastreio = `<p>Codigo de Rastreio:<a href="https://api.linketrack.com/track/json?user=teste&token=1abcd00b2731640e886fb41a8a9671ad1434c599dbaa0a0de9a5aa619f29a83f&codigo=${rastreio.codigoRastreio}">${rastreio.codigoRastreio}</a></p>`;
                    const dataCompra = `<p>Data da Compra: ${rastreio.dataDeCompra}</p>`;

                    lista.insertAdjacentHTML('beforeend', nome);
                    lista.insertAdjacentHTML('beforeend', empresa);
                    lista.insertAdjacentHTML('beforeend', codigoRastreio);
                    lista.insertAdjacentHTML('beforeend', dataCompra);

                });
            }
        })
        .catch(error => console.log(error));
}


function limpaBusca(element) {
    while (element.firstElementChild) {
        element.firstElementChild.remove();
    }
}




function pesquisaProduto(id) {
    fetch(`https://localhost:44384/api/User?produto=${id}&email=${email}`)
        
        .then(resp => {
            return resp.json();
        })
        .then(data => {
            if (id == null && id.length < 1) {
                limpaBusca(lista);
                const erro = `<h4>Nenhum produto foi encontrado...</h4>`;
                lista.insertAdjacentHTML('beforeend', erro);
                throw new Error('Informe o produto no campo de busca')
            }            
            else {
                limpaBusca(lista);
                console.log(data);                
                data.forEach(rastreio => {
                    const email = `<h4>Email: ${rastreio.email}</h4>`;
                    const nome = `<h4>Nome do Produto: ${rastreio.nomeDoProduto}</h4>`;
                    const empresa = `<p>Empresa: ${rastreio.empresa}</p>`;
                    const codigoRastreio = `<p>Codigo de Rastreio:<a href="https://api.linketrack.com/track/json?user=teste&token=1abcd00b2731640e886fb41a8a9671ad1434c599dbaa0a0de9a5aa619f29a83f&codigo=` + `${rastreio.codigoRastreio}>${rastreio.codigoRastreio}</a></p>`;
                    const dataCompra = `<p>Data da Compra: ${rastreio.dataDeCompra}</p>`;

                    lista.insertAdjacentHTML('beforeend', nome);
                    lista.insertAdjacentHTML('beforeend', empresa);
                    lista.insertAdjacentHTML('beforeend', codigoRastreio);
                    lista.insertAdjacentHTML('beforeend', dataCompra);

                });
            }
        })
        .catch(error => console.log(error));
        

}
