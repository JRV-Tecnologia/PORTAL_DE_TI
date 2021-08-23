$(document).ready(function () {
    var userData = null;
    //Permissões do usuário
    $(".user-permissions").on('click', function () {
        let user = $(this).attr("data-item");
        let username = $(this).attr("data-name");
        $('body').addClass('busy');
        $("#configurationSpinnerUser").show();

        $("#modalPermissoesDeUsuario").attr("data-item", user);
        $("#modalPermissoesDeUsuario_Name").html(username);
        
        $(".modal-permissoes-de-usuario-input").each(function () {
            $(this).prop('checked', false);
        });
        $("#permissionUser").val(0);
        $(".usuario-tab-pane").removeClass("active");

        $.get("/Permissions/Index", { id: user, type: 'user' })
            .done(function (data) {
                $(data).each(function (t) {                    
                    $(`#prm-usr-${this.acaoDBId}-${this.controleDBId}`).prop('checked', true);;
                });
                $('body').removeClass('busy');
                $("#configurationSpinnerUser").hide();
                $("#modalPermissoesDeUsuario").modal('show');
            });  

        
    });

    $("#permissionUser").on('change', function () {
        let user = $("#modalPermissoesDeUsuario").attr("data-item");
        let control = $(this).val();

        $(".usuario-tab-pane").removeClass("active");
       
        //$.get("/Permissions/Index", { user: user, control: control })
        //    .done(function (data) {

        //        $(data).each(function (t) {
        //            $(`#prm-${this.acaoDBId}-${this.controleDBId}`).prop('checked', true);;
        //        });


        //    });  

        var selectedPermissionUser = document.getElementById("permissionUser").value;
        var newUserClass = ['#usr-', selectedPermissionUser].join('');
        $(newUserClass).addClass("active");
    });

    $("#modalPermissoesDeUsuario_Cancel").on('click', function () {
        $("#modalPermissoesDeUsuario").modal('hide');

    });

    $("#modalPermissoesDeUsuario_Save").on('click', function () {
        let user = $("#modalPermissoesDeUsuario").attr("data-item");

        var formData = new FormData(); 
        formData.append('id', user);
        formData.append('type', 'user');

        $(".modal-permissoes-de-usuario-input").each(function() {
            formData.append($(this).attr('id'), $(this).is(':checked') ? "1" : "0");
        });

        
        $.ajax({
            url: "/Permissions/Edit",
            type: 'POST',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                $("#modalPermissoesDeUsuario").modal('hide');
            }
        });

    });


    //permissões do grupo
    $(".group-permissions").on('click', function () {
        let group = $(this).attr("data-item");
        let groupname = $(this).attr("data-name");
        $('body').addClass('busy');
        $("#configurationSpinnerGroup").show();

        $("#modalPermissoesDeGrupo").attr("data-item", group);
        $("#modalPermissoesDeGrupo_Name").html(groupname);

        $(".modal-permissoes-de-grupo-input").each(function () {
            $(this).prop('checked', false);
        });
        $("#permissionGroup").val(0);
        $(".grupo-tab-pane").removeClass("active");

        $.get("/Permissions/Index", { id: group, type: 'group' })
            .done(function (data) {
                $(data).each(function (t) {
                    $(`#prm-grp-${this.acaoDBId}-${this.controleDBId}`).prop('checked', true);;
                });
                $('body').removeClass('busy');
                $("#configurationSpinnerGroup").hide();
                $("#modalPermissoesDeGrupo").modal('show');
            });


    });

    $(".group-members").on('click', function () {
        let group = $(this).attr("data-item");
        let groupname = $(this).attr("data-name");
        $('body').addClass('busy');
        $("#modalPermissoesDeGrupoMembro_Incluir").addClass("disabled");
        $("#configurationSpinnerGroup").show();

        $("#modalPermissoesDeGrupoMembro").attr("data-item", group);
        $("#modalPermissoesDeGrupoMembro_Name").html(groupname);

        $.get("/Permissions/Index", { id: group, type: 'member' })
            .done(function (data) {

                $("#modalPermissoesDeGrupoMembro_table tbody").html('');

                $(data).each(function (t) {

                    var newRow = $(`<tr>`);
                    var cols = "";

                    cols += `<td><input type='hidden' class="modal-permissoes-de-grupo-member-input" value='${this.usuarioDBId}' />${this.nomeCompleto}</td>`;
                    cols += '<td><a href="javascript:void(0);" class="remove" title="Remover">X</a></td>';

                    newRow.append(cols);
                    $("#modalPermissoesDeGrupoMembro_table tbody").append(newRow);

                });

                $(".remove").on('click', function () {
                    this.parentElement.parentElement.remove();
                });

                //$('body').removeClass('busy');
                $("#configurationSpinnerGroup").hide();
                $("#modalPermissoesDeGrupoMembro").modal('show');

                $('.basicAutoComplete').autoComplete({
                    events: {
                        search: function (qry, callback) {
                            // let's do a custom ajax call
                            $(".dropdown-menu a").unbind('click');
                            $.ajax(
                                '/permissions/Index?id=0&type=allUsers',
                                {
                                    data: { 'qry': qry }
                                }
                            ).done(function (res) {

                                userData = res;
                                callback(res);
                                $(".dropdown-menu").toggle();

                                

                                $(".dropdown-menu a").on("click", function () {
                                    var name = $(this).text();
                                    var id = userData.filter(f => f.text === name)[0].value;
                                    
                                    $("#modalPermissoesDeGrupoMembro_includeUserId").val(userData.filter(f => f.text === name)[0].value);

                                    $(".dropdown-menu").toggle();
                                    var memberExists = false
                                    $(".modal-permissoes-de-grupo-member-input").each(function () {
                                        if (parseInt($(this).val()) === id) {
                                            memberExists = true
                                        }
                                    })
                                    if (memberExists === false) {
                                        $("#modalPermissoesDeGrupoMembro_Incluir").removeClass("disabled");
                                    }                                    
                                });

                            });
                        }
                    }
                });
            });

    });

    $("#permissionGroup").on('change', function () {
        let group = $("#modalPermissoesDeGrupo").attr("data-item");
        let groupname = $(this).val();

        $(".grupo-tab-pane").removeClass("active");

        //$.get("/Permissions/Index", { user: user, control: control })
        //    .done(function (data) {

        //        $(data).each(function (t) {
        //            $(`#prm-${this.acaoDBId}-${this.controleDBId}`).prop('checked', true);;
        //        });


        //    });  

        var selectedPermissionGroup = document.getElementById("permissionGroup").value;
        var newGroupClass = ['#grp-', selectedPermissionGroup].join('');
        $(newGroupClass).addClass("active");
    });

    $("#modalPermissoesDeGrupoMembro_Incluir").on('click', function () {

        $("#modalPermissoesDeGrupoMembro_Incluir").addClass("disabled");
        var id = $("#modalPermissoesDeGrupoMembro_includeUserId").val();
        var name = $("#modalPermissoesDeGrupoMembro_includeUserName").val();
        
             

        var newRow = $(`<tr>`);
        var cols = "";

        cols += `<td><input type='hidden' class="modal-permissoes-de-grupo-member-input" value='${id}' />${name}</td>`;
        cols += '<td><a href="javascript:void(0);" class="remove" title="Remover">X</a></td>';

        newRow.append(cols);
        $("#modalPermissoesDeGrupoMembro_table tbody").append(newRow);

        $(".remove").unbind();
        $(".remove").on('click', function () {
            this.parentElement.parentElement.remove();
        });


    });

    $("#modalPermissoesDeGrupo_Cancel").on('click', function () {
        $("#modalPermissoesDeGrupo").modal('hide');
 

    });

    $("#modalPermissoesDeGrupo_Save").on('click', function () {
        let group = $("#modalPermissoesDeGrupo").attr("data-item");

        var formData = new FormData();
        formData.append('id', group);
        formData.append('type', 'group');

        $(".modal-permissoes-de-grupo-input").each(function () {
            formData.append($(this).attr('id'), $(this).is(':checked') ? "1" : "0");
        });


        $.ajax({
            url: "/Permissions/Edit",
            type: 'POST',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                $("#modalPermissoesDeGrupo").modal('hide');
            }
        });

    });

    $("#modalPermissoesDeGrupoMembro_Cancel").on('click', function () {
        $("#modalPermissoesDeGrupoMembro").modal('hide');
    });

    $("#modalPermissoesDeGrupoMembro_Save").on('click', function () {
        let group = $("#modalPermissoesDeGrupoMembro").attr("data-item");

        var formData = new FormData();
        formData.append('id', group);
        formData.append('type', 'member');

        $(".modal-permissoes-de-grupo-member-input").each(function () {
            formData.append('user-members', $(this).val());
        });


        $.ajax({
            url: "/Permissions/Edit",
            type: 'POST',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                $("#modalPermissoesDeGrupoMembro").modal('hide');
            }
        });

    });


    

});

