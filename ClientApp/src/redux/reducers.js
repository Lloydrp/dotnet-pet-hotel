export const petOwnersReducer = (state = [], action) => {
    if (action.type === 'SET_PETOWNERS')
      return action.payload;
    return state;
  }
  
export const petsReducer = (state = [], action) => {
    if (action.type === 'SET_PETS')
      return action.payload;
    return state;
  }