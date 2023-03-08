const submit = document.querySelector("#ok")
const nomeProduto = document.querySelector("#produto")
const empresa = document.querySelector("#empresa")
const codigoRastreio = document.querySelector("#rastreio")
const dataDaCompra = document.querySelector("#dataCompra")
const email = document.querySelector("#email").value
const lista = document.querySelector('#listahome')

submit.onclick = () => {
    const inputs = {
        "email": email,
        "NomeDoProduto": nomeProduto.value,
        "Empresa": empresa.value,
        "CodigoRastreio": codigoRastreio.value,
        "DataDeCompra": dataDaCompra.value

    }

    fetch("https://localhost:44360/api/User",
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(inputs),
        }).then(() => {
            const confirmacao = `<h4>Rastreio cadastrado com sucesso</h4>`;
            lista.insertAdjacentHTML('beforeend', confirmacao);
        })
        .catch(error => console.log(error));

}