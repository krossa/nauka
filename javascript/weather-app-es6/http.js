export class Http {
  static fetchData(url) {
    return new Promise((resolve, reject) => {
      const http = new XMLHttpRequest();
      http.open("GET", url);
      http.onreadystatechange = function() {
        if (http.readyState == XMLHttpRequest.DONE && http.status == 200) {
          const responseData = JSON.parse(http.responseText);
          resolve(responseData);
        } else if (http.readyState == XMLHttpRequest.DONE) {
          reject("Something went wrong");
        }
      };
      http.send();
    });
  }
}
