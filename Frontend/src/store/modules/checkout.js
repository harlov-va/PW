import * as productModel from './articles';
export default {
    namespaced: true,
	state: {
        info: [
			{
				name: 'Full Name',
				value: '',
				pattern: /^[а-яА-ЯёЁ ]{2,30}$/,
				status:false
			},
			{
				name: 'Phone',
				value: '',
				pattern: /^[0-9]{7,14}$/,
				status:false
			},
			{
				name: 'Email',
				value: '',
				pattern: /\S+@\S+\.\S+/,
				status:false
			}
		],
		name:'',
		formSubmited: false,
		formProcess: false,
		delivery:[]
    },
	getters: {
		info(state){
			return state.info;
		},
		validCnt(state){
			let done = 0;

			for(let i = 0; i < state.info.length; i++){
				if(state.info[i].status){
					done++;
				}
			}
			return done;
		},
		formSubmited(state){
			return state.formSubmited;
		},
		formProcess(state){
			return state.formProcess;
		},
		delivery(state){
			return state.delivery;
		}
	},
	mutations: {
		changeData(state, payload){
			state.info[payload.index].value = payload.value;
		},
		setInfoStatus(state, data){
			state.info[data.i].status = data.status;
		},
		onSubmited(state,bool){
            // state.formSubmited === true ? state.formSubmited = false : state.formSubmited = true;
            // state.name = 'Hello, ' + state.info[0].value;
            state.formSubmited = bool;
		},
		startSubmit(state,payload){
			state.formProcess = payload;
		},
		submitted(state){
			state.formSubmited = true;
			state.formProcess = false;
		},
		setDelivery(state,data){
			state.delivery[data.i].status = data.status;
		},
		clearDelivery(state){
			state.delivery = [];
		},
		loadDelivery(state, data){
			state.delivery = data;
		}
	},
	actions: {
		async submit(store, data){
			store.commit('startSubmit',true);
			productModel.sendOrder(data).then((status) =>{
				if(status === 200){
					store.commit('submitted');
					store.dispatch('error/changeStateComment',{state: true, text: 'Order shipped'},{ root: true });
				}
				else{
					store.dispatch('error/changeStateComment',{state: false,text: 'Order not shipped'},{ root: true });
					store.commit('startSubmit',false);
				}

			}).catch(() => {
				store.dispatch('error/changeStateComment',{state: false,text: 'Order not shipped'},{ root: true });
				store.commit('startSubmit',false);
			});
		},
		async loadDelivery(store){
			store.commit('clearDelivery');
			let delivery = await productModel.getDelivery();
			store.commit('loadDelivery', JSON.parse(delivery));
		}
	}
};