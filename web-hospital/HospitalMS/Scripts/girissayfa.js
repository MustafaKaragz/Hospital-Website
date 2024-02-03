function redirectTo(url) {
   
    document.getElementById('loading').style.display = 'block';
  
    
    setTimeout(function() {
      document.getElementById('loading').style.display = 'none';
      window.location.href = url;
    }, 2000);
  }
  