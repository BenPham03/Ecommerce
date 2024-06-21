import React from "react"
import Detail from "../asset/css/Detail.module.css"

export default function ProductDetail(props:any){
    return(
      <div className={Detail.container} dangerouslySetInnerHTML={{__html: props.data.detail}}></div>
    )}
