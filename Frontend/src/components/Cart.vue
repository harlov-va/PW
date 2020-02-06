<template>
	<div>
		<h1>Cart</h1>
		<hr>
		<div v-if="empty"
			 class="alert alert-warning">
			Your cart is empty
		</div>
		<template v-else>
			<table class="table table-bordered table-hover">
				<thead>
					<tr>
						<th>Title</th>
						<th>Price</th>
						<th>Amount</th>
					</tr>
				</thead>	
				<tbody>
					<tr v-for="(product,index) in products">
						<td>{{ product.title }}</td>
						<td>{{ product.price }}</td>
						<td>
							<AppInputNumber								
								:value="amountProducts[index]"								
								:key="index"
								@changedata="onChangeData(index, $event)"
							></AppInputNumber>
						</td>
					</tr>
					<tr>
						<td></td>
						<td ><p class="text-right">Сумма оплаты:</p></td>
						<td>{{ sum }}</td>
					</tr>
				</tbody>	
			</table>
			<button @click="onOrder"
					class="btn btn-success"
					>
				Order Now
			</button>
		</template>
	</div>
</template>

<script>
	import {mapGetters} from 'vuex';
	import AppInputNumber from './InputNumber';

	export default {
		data(){
			return {
				sum:0
			}			
		},
		mounted(){
			this.sum = 0;
			this.products.forEach((element, index) => {
				this.sum += element.price * this.amountProducts[index];
			});
		},
		computed: {
			...mapGetters('products', {
				productsAll: 'items'
			}),
			...mapGetters('cart', {
				productsInCart: 'products',
				amountProducts: 'amountProducts'
			}),
			products(){
				return this.productsAll.filter((elem) => {
					return this.productsInCart.indexOf(elem.id_product) !== -1;
				});
			},
			empty(){
				return this.products.length === 0;
			}
		},
		methods: {
			onOrder(){
				this.$router.push('/checkout');
			},
			onChangeData(index, data){
				this.$store.commit('cart/changeValue', {
					index: index,
					value: data.value
				});
				this.sum = 0;
				this.products.forEach((element, index) => {
					this.sum += element.price * this.amountProducts[index];
				});
			}
		},
		components:{
			AppInputNumber
		}
	}
</script>