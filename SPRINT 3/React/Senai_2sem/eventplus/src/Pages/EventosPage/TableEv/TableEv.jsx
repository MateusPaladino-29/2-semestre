import React from 'react';
import './TableEv.css';
import editPen from '../../../assets/images/images/edit-pen.svg'
import trashDelete from '../../../assets/images/images/trash-delete.svg'
// import { dateFormatDbToView } from '../../../Utils/stringFunction';

const TableEv = ({ dados, fnUpdate, fnDelete }) => {
    return (
        <table className='table-data'>
            <thead className="table-data__head">
                <tr className="table-data__head-row">
                    <th className="table-data__head-title table-data__head-title--little">Eventos</th>
                    <th className="table-data__head-title table-data__head-title--little">Descrição</th>
                    <th className="table-data__head-title table-data__head-title--little">Tipo Evento</th>
                    <th className="table-data__head-title table-data__head-title--little">Data Evento</th>
                    <th className="table-data__head-title table-data__head-title--little">Editar</th>
                    <th className="table-data__head-title table-data__head-title--little">Deletar</th>
                </tr>
            </thead>



            <tbody>
                {dados.map((evento) => (
                    <tr className="table-data__head-row">
                        <td className="table-data__data table-data__data--big">
                            {evento.nomeEvento}
                        </td>
                        <td className="table-data__data table-data__data--big">
                            {evento.descricao}
                        </td>
                        <td className="table-data__data table-data__data--big">
                            {evento.tiposEvento.titulo}
                        </td>
                        <td className="table-data__data table-data__data--big">
                           {new Date(evento.dataEvento).toLocaleDateString()}
                        </td>


                        <td className="table-data__data table-data__data--little">
                            <img className="table-data__icon" onClick={() => { fnUpdate(evento) }} src={editPen} alt="" />
                        </td>

                        <td className="table-data__data table-data__data--little">
                            <img className="table-data__icon" onClick={() => { fnDelete(evento.idEvento) }} src={trashDelete} alt="" />
                        </td>
                    </tr>

                ))}

            </tbody>
        </table>
    );
};

export default TableEv;