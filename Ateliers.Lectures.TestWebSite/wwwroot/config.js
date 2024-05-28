// config.js
const config = {
    development: {
        baseURL: 'https://localhost:7061'
    },
    production: {
        baseURL: 'https://your-production-url.com'
    }
};

// 環境変数をHTMLから取得し、window.configに設定
const environment = window.env || 'development';
window.config = config[environment];
