angular.module('forms', [])
    .controller('formsController', function ($scope, $http) {
        var formList = this;
        formList.data = []
        formList.dataShow = []
        $http.get("/form/getforms", { withCredentials: true }).then((res) => { 
            formList.data = JSON.parse(res.data)
            formList.dataShow = formList.data
        })

        formList.filter = () => {
            if (!formList.search) {
                formList.dataShow = formList.data
                return;
            }
            let f = formList.search.toLowerCase()
            formList.dataShow = formList.data.filter(form => form.name.includes(f) || form.description.includes(f) )
        }

        formList.cleanNewFormFieldOptions = () => {
            formList.newName = ""
            formList.newDescription = ""
            formList.newRequired = false
            formList.newType = "STRING"
        }

        formList.cleanNewForm = ()=>{
            formList.newForm = {
                "name": "",
                "description": "",
                "formFields": []
            }
            formList.cleanNewFormFieldOptions()
        }

        formList.addField = ()=>{
            let newField = {
                name: formList.newName,
                description: formList.newDescription ? formList.newDescription : "",
                required: formList.newRequired ? true : false,
                dataType: formList.newType ? formList.newType : "STRING"
            }

            formList.newForm = {
                ...formList.newForm,
                formFields: [...formList.newForm.formFields, newField]
            }

            formList.cleanNewFormFieldOptions()

            console.log(formList.newForm)
        }

        formList.saveForm = async () => {
            formList.newForm.name = formList.newFormName
            formList.newForm.description = formList.newFormDescription ? formList.newFormDescription : ""
            let response = await fetch("form/CreateForm", {
                method: "POST", // *GET, POST, PUT, DELETE, etc.
                body: JSON.stringify(formList.newForm), // body data type must match "Content-Type" header
                headers: {
                    "Content-Type": "application/json"
                }
            });
            response = await response.json()
            response = JSON.parse(response)
            window.location.href = `Form/Forms/${response.id}`
        }

    });
