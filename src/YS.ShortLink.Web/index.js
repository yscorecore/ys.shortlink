+(function () {

    document.querySelector("form").onsubmit = (event) => {
        event.target.url.value && toShort(event.target.url.value);
        event.preventDefault();
    }
    /**
     * 
     * @param {String} url 
     */
    function toShort(url) {
        fetch(`http://localhost/short?url=${url}`, { method: "post", mode: 'cors' })
            .then(r => r.text())
            .then(r => {
                document.querySelector('.short-link').innerHTML = r;
                document.querySelector('.original-link').innerHTML = url;
                document.querySelector('.result').style.display = "block";
            });
    }

})();