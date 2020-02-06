	<template>
		<div>
			<form id="uploadForm" name="uploadForm" enctype="multipart/form-data">
				<input type="file" id="file" name="files" ><br>
				<input class="btn btn-primary" type=button value="Upload file" @click="this.uploadFiles">
			</form>		
		</div>
	</template>

<script>
	import {mapGetters,mapActions} from 'vuex';
	import * as ProductModel from '../store/modules/articles';
	export default {
		data(){
			return{
				
			}
		},
		computed: {

		},
		methods: {
			...mapActions('error', {
				changeStateComment: 'changeStateComment'
			}),
			async uploadFiles () {
				const data = new FormData(document.getElementById('uploadForm'));
				var xmlFile = document.querySelector('#file');
				if(xmlFile.files[0] === undefined) {
					this.changeStateComment({state: false, text:'Select file to upload'}); 
					return;
				} else{
					data.append('file', xmlFile.files[0]);
				} 
				ProductModel.sendXml(data).then((status) =>{
				if(status === 200){					
					this.changeStateComment({state: true, text:'File downloaded'});
				}
				else{
					this.changeStateComment({state: false, text:'Failed to upload file to server'});
				}
				}).catch(() => {
					this.changeStateComment({state: false, text:'Failed to upload file to server'});
				});
			}					
		}
	}
</script>