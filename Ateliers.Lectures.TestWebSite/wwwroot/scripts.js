const baseURL = window.config.baseURL;

document.getElementById('inquiryForm').addEventListener('submit', async function (event) {
    event.preventDefault();

    const inquiryItems = Array.from(document.querySelectorAll('input[name="inquiryItems"]:checked')).map(item => item.value);
    const foundOutMethods = Array.from(document.querySelectorAll('input[name="foundOutMethods"]:checked')).map(item => item.value);

    const formData = {
        InquiryItems: inquiryItems,
        Name: document.getElementById('name').value,
        Email: document.getElementById('email').value,
        PhoneNumber: document.getElementById('phoneNumber').value,
        CompanyName: document.getElementById('companyName').value,
        Department: document.getElementById('department').value,
        FoundOutMethods: foundOutMethods,
        Content: document.getElementById('content').value
    };

    try {
        const response = await fetch(`${baseURL}/api/inquiry`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        });

        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        const data = await response.json();

        if (data.success) {
            alert(data.message);  // 成功メッセージの表示
            this.reset();  // フォームのリセット
        } else {
            alert('お問い合わせの送信に失敗しました。');
        }
    } catch (error) {
        console.error('Error:', error);
        alert(`お問い合わせの送信中にエラーが発生しました。詳細: ${error.message}`);
    }
});
