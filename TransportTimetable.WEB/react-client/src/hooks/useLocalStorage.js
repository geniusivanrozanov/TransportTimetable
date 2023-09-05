export const useLocalStorage = (storage) => {
  return {
    Add(item){
      const arr = JSON.parse(localStorage.getItem(storage)) ?? []
      arr.push(item)
      localStorage.setItem(storage, JSON.stringify(arr))
    },
    Remove(item){
      const arr = JSON.parse(localStorage.getItem(storage)) ?? []
      const index = arr.indexOf(item)
      if (index > -1)
        arr.splice(index, 1)
      localStorage.setItem(storage, JSON.stringify(arr))
    },
    Exsists(item) {
      const arr = JSON.parse(localStorage.getItem(storage)) ?? []
      const index = arr.indexOf(item)
      return index > -1
    }
  }
}