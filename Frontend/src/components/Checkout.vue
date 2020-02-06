<template>
			<transition name="boom" 
				appear
				mode="out-in"
				>
				<form @submit.prevent="onSubmit" v-if="!formSubmited">
					<div class="progress">
						<div class="progress-bar" :style="progressWidth"></div>
					</div>
					<div>
						<app-input v-for="(item, index) in  info"
								:name="item.name"
								:value="item.value"
								:pattern="item.pattern"
								:key="index"
								@changedata="onChangeData(index, $event)"
								@changeStatus="onChangeStatus(index, $event)"
						>
						</app-input>
						<RadioGroup
							:title="'Способы доставки'"
							:answers="namesDeliveris"
							@chousevariant="onChouseAnswer($event)"
						></RadioGroup>
					</div>
					<button :class="btnClass" :disabled="!((this.validCnt === this.info.length) && (this.products.length > 0))">
						{{ btnText }}
					</button>
				</form>
				<div v-else>
					<h3
					>
					Order shipped
					</h3>
				</div>
			</transition>
</template>

<script>
	import AppInput from './Input';
	import RadioGroup from './radioGroup';
	import {mapGetters,mapMutations, mapActions} from 'vuex';

	export default {
		data(){
			return {
				deliveryId:0
			}
		},
		created(){
			this.$store.dispatch('checkout/loadDelivery');
		},
		computed: {
			...mapGetters('checkout',{
				info:'info',
				validCnt:'validCnt',
				formSubmited:'formSubmited',
				formProcess:'formProcess',
				delivery:'delivery'
			}),
			...mapGetters('cart', {
				products:'products',
				amountProducts: 'amountProducts'
			}),
			progressWidth(){
				return {
					width: (this.validCnt / this.info.length * 100) + '%'
				}
			},
			btnClass(){
				return this.formProcess ? 'btn btn-default' : 'btn btn-primary';
			},
			btnText(){
				return this.formProcess ? 'Loading...' : 'Send Data';
			},
			namesDeliveris(){
				let array = [];
				this.delivery.forEach((element,index) => {
					array[index] = element.title;
				});
				return array;
			}
		},
		methods: {
			...mapActions('checkout', {
				sendData: 'sendData'
			}),
			...mapActions('cart', {
				removeAll: 'removeAll'
			}),
			...mapActions('error', {
				changeStateComment: 'changeStateComment'
			}),
			onChangeData(index, data){
				this.$store.commit('checkout/changeData', {
					index: index,
					value: data.value
				});
			},
			onChangeStatus(index, isValid){
				this.$store.commit('checkout/setInfoStatus',{
					i: index,
					status: isValid
				});
			},
			onSubmit(){
				let order = {};
				for(let i = 0; i< this.products.length; i++){
					if(this.amountProducts[i] !=='0'){
						order[this.products[i]] =  this.amountProducts[i];
					}
				};
				let person = {};
				this.info.forEach(element => {
					person[element.name] = element.value;
				});
				this.delivery.length !== 0 ? person['Delivery'] = this.delivery[this.deliveryId].id : person['Delivery'] = 1;
				this.$store.dispatch('checkout/submit',{
					'order': order,
					'person': person
				});				
				this.removeAll();
			},
			onChouseAnswer(data){
				this.deliveryId = data;
			}
		},		
		components: {
			AppInput,
			RadioGroup
		}
	}
</script>

<style scoped>
	.wrapper{
		max-width: 600px;
		margin: 20px auto;
	}

	.boom-enter{
		
	}

	.boom-enter-active{
		animation: slideIn 0.5s;
	}

	.boom-enter-to{
		
	}

	.boom-leave{
		
	}

	.boom-leave-active{
		animation: slideOut 0.5s;
	}

	.boom-leave-to{
		
	}

	@keyframes slideIn{
		from{transform: translateX(100vw);}
		to{transform: translateX(0px);}
	}

	@keyframes slideOut{
		from{transform: translateX(0px);}
		to{transform: translateX(-100vw);}
	}
</style>
