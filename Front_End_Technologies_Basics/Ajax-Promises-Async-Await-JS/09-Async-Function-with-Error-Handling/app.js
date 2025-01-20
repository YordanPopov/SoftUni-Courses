async function promiseRejectionAsync() {
   console.log("Before promise!");
   try {
      await throwError();
      console.log("Not throw error");
   } catch (error) {
      console.log(error);
   }

}

function throwError() {
   return new Promise((resolve, reject) => {
      setTimeout(() => {
         reject("Throw error");
      }, 2000);
   });
}